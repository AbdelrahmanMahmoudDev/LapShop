using System.Diagnostics;
using LapShop.Services.Item;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService  _itemService;
        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _itemService.PrepareHomepage();
            return View(list);
        }
    }
}
