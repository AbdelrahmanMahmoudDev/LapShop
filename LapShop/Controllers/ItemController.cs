using LapShop.Domains.ViewModels;
using LapShop.Services.Item;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult Item(int id)
        {
            ItemDetailsVM itemDetails = new ItemDetailsVM
            {
                Item = _itemService.GetSingle(id),
                RelatedProducts = _itemService.PrepareDashboard(null).Select(e => new Domains.Item()
                {
                    ItemId = e.ItemId,
                    ItemName = e.ItemName,
                    SalesPrice = e.SalesPrice,
                    PurchasePrice = e.PurchasePrice,
                    ImageName = e.ImageName,
                    Gpu = e.Gpu,
                    HardDisk = e.HardDisk,
                    Processor = e.Processor,
                    RamSize = e.RamSize,
                }).ToList(),
            };
            return View(itemDetails);
        }
    }
}
