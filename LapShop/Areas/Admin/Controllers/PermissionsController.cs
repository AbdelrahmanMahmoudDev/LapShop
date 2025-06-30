using System.Reflection;
using LapShop.Areas.Admin.Models;
using LapShop.Data;
using LapShop.Services.Permissions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PermissionsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPermissionsService _permissionsService;

        public PermissionsController(UserManager<ApplicationUser> userManager, IPermissionsService permissionsService)
        {
            _userManager = userManager;
            _permissionsService = permissionsService;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> UserDetails(string userId)
        {
            var asm = Assembly.GetAssembly(typeof(Program));
            var controllerActionGroups = asm?.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new WebsiteTechnicalData
                    {
                        Area = x.DeclaringType?.GetCustomAttributes(typeof(AreaAttribute), true).FirstOrDefault() is AreaAttribute areaAttr ? areaAttr.RouteValue : "",
                        Controller = x.DeclaringType?.Name ?? string.Empty,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = string.Join(", ", x.GetCustomAttributes().Select(attr => attr.GetType().Name))
                    })
                    .OrderBy(x => x.Area).ThenBy(x => x.Controller).ThenBy(x => x.Action)
                    .GroupBy(x => x.Area)
                    .Select(g => new AreaGroup
                    {
                        Area = g.Key ?? string.Empty,
                        Controllers = g.GroupBy(x => x.Controller).Select(g => new ControllerActionGroup
                        {
                            Controller = g.Key,
                            TechnicalData = g.ToList()
                                        
                        })
                        .OrderBy(c => c.Controller)
                        .ToList()
                    })
                    .OrderBy(a => a.Area)
                    .ToList();

            UserDetailsVM userDetails = new UserDetailsVM
            {
                UserId = userId,
                AreaGroups = controllerActionGroups,
            };


            List<Domains.UserPermissions> userPermissions = await _permissionsService.GetPermissionsByUser(userId);

            foreach (var areaGroup in userDetails.AreaGroups)
            {
                foreach (var controllerGroup in areaGroup.Controllers)
                {
                    foreach (var action in controllerGroup.TechnicalData)
                    {
                        var permission = userPermissions.FirstOrDefault(up => up.Area == areaGroup.Area && up.Controller == controllerGroup.Controller && up.Action == action.Action);
                        if (permission != null)
                        {
                            action.IsSelected = true;
                            areaGroup.SelectedActions.Add($"{userId}|{areaGroup.Area}|{controllerGroup.Controller}|{action.Action}");
                        }
                    }
                }
            }

            return View(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Save(List<string> SelectedActions)
        {
            if (SelectedActions == null || SelectedActions.Count == 0)
            {
                ModelState.AddModelError("", "No actions selected.");
                return RedirectToAction($"Index");
            }

            await _permissionsService.Save(SelectedActions);

            return RedirectToAction("Index");
        }
    }
}
