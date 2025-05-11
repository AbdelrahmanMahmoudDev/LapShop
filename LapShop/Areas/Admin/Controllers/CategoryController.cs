using LapShop.Services.Category;
using LapShop.Domains;
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
            IEnumerable<Category> Categories = await _CategoryService.PrepareDashboard();
            return View("Index", Categories);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id is not null)
            {
                return View("Edit", await _CategoryService.GetTargetCategory(Convert.ToInt32(Id)));
            }
            return View("Edit", new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Category Category, IFormFile File)
        {
            bool IsSuccess = false;
            if (Category.CategoryId == 0)
            {
                Category.ImageName = await Utilities.FileUtility.SaveFile(File, "Images\\Categories", [".jpg", ".jpeg", ".png"]);
                IsSuccess = await _CategoryService.SaveNew(Category);
            }
            else
            {
                // Category Updates may not update images
                if (File is not null)
                {
                    Category.ImageName = await Utilities.FileUtility.SaveFile(File, "Images\\Categories", [".jpg", ".jpeg", ".png"]);
                }
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
            string ImagePath = await _CategoryService.RemoveCategory(id);

            if (ImagePath is null)
            {
                return StatusCode(500, "A server side error occured while processing your request");
            }
            else
            {
                Utilities.FileUtility.DeleteFile(ImagePath);
            }
            return RedirectToAction("Index");
        }
    }
}
