using System.Security.Claims;
using LapShop.Services.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LapShop.Filters
{
    public class PermissionFilter : ActionFilterAttribute
    {
        private readonly IPermissionsService _permissionsService;
        public PermissionFilter(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            var controllerName = controller?.GetType().Name;
            var actionName = context.ActionDescriptor?.DisplayName?.Split('.').Last().Split(' ').First();
            var areaName = controller?.RouteData.Values["area"]?.ToString() ?? "Root";

            if (areaName == "Root")
            {
                await next.Invoke();
                return;
            }

            var currentUserId = context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
            {
                context.Result = new RedirectToActionResult("Login", "User", new { area = "" });
                return;
            }

            var queryResult = await _permissionsService.GetPermissionByAction(currentUserId, areaName, controllerName!, actionName!);

            if (queryResult == null)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "User", new { area = "" });
                return;
            }
           await next.Invoke();
        }
    }
}
