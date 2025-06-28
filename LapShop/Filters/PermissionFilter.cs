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

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            var actionName = context.ActionDescriptor?.DisplayName?.Split('.').Last();
            var controllerName = controller?.GetType().Name;
            var areaName = controller?.RouteData.Values["area"]?.ToString() ?? "Root";

            var currentUserId = context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
            {
                if(!areaName.Equals("Root", StringComparison.OrdinalIgnoreCase))
                    context.Result = new RedirectToActionResult("Login", "User", new { area = "" });

                return;
            }

            var queryResult = _permissionsService.GetPermissionByAction(currentUserId, areaName, controllerName!, actionName!);

            if(queryResult == null)
            {
                if(!areaName.Equals("Root", StringComparison.OrdinalIgnoreCase))
                    context.Result = new RedirectToActionResult("AccessDenied", "User", new { area = "" });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
