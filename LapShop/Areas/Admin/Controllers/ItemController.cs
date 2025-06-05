using Microsoft.AspNetCore.Mvc;
using LapShop.Services.Item;
using LapShop.Domains.ViewModels;

namespace LapShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly IItemService _ItemService;
        public ItemController(IItemService itemService)
        {
            _ItemService = itemService;
        }

        public IActionResult Index()
        {
            IQueryable<VwItemsVM> queryables = _ItemService.PrepareDashboard(null);
            return View("Index", queryables.ToList());
        }

        public IActionResult Search(string searchValue)
        {
            IQueryable<VwItemsVM> queryables = _ItemService.PrepareDashboard(searchValue);

            return Ok(queryables.ToList());
        }

        public IActionResult Edit(int? id)
        {
            if (id is not null)
            {
                return View("Edit", _ItemService.GetSingle(id));
            }
            return View("Edit", _ItemService.GetSingle(null));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(VwItemsVM item)
        {
            try
            {
                await _ItemService.Save(item);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "A server side error occurred while processing your request: " + ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ItemService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "A server side error occurred while processing your request: " + ex.Message);
            }
        }
    }
}
