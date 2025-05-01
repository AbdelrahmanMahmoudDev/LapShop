using System.Threading.Tasks;
using LapShop.BL;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService CatService)
        {
            _CategoryService = CatService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Models.Category> Categories = await _CategoryService.PrepareDashboard();
            return View("Index", Categories);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id is not null)
            {
                return View("Edit", await _CategoryService.GetTargetCategory(Convert.ToInt32(Id)));
            }
            return View("Edit", new Models.Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Models.Category Category)
        {
            bool IsSuccess = false;
            if (Category.CategoryId == 0)
            {
                IsSuccess = await _CategoryService.SaveNew(Category);
            }
            else
            {
                IsSuccess = await _CategoryService.SaveUpdate(Category);
            }

            if (!IsSuccess)
            {
                return StatusCode(500, "A server side error occured while processing your request");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool IsSuccess = await _CategoryService.RemoveCategory(id);

            if (!IsSuccess)
            {
                return StatusCode(500, "A server side error occured while processing your request");
            }
            return RedirectToAction("Index");
        }
    }
}
