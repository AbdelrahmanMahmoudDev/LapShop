using LapShop.BL;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _CategoryService;
        public HomeController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        public async Task<IActionResult> Category()
        {
            IEnumerable<Models.Category> Categories = await _CategoryService.PrepareDashboard();
            return View("Category", Categories);
        }
    }
}
