using LapShop.Services.Slider;
using LapShop.Domains;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _SliderService;
        public SliderController(ISliderService sliderService)
        {
            _SliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _SliderService.PrepareDashboard();
            return View("Index", sliders);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id is not null)
            {
                return View("Edit", await _SliderService.GetTargetSlider(Convert.ToInt32(Id)));
            }
            return View("Edit", new Slider());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Slider Slider, IFormFile File)
        {
            bool IsSuccess = false;
            if (Slider.SliderId == 0)
            {
                string windowsPath = await Utilities.FileUtility.SaveFile(File, "Images\\Sliders", [".jpg", ".jpeg", ".png"]);
                Slider.ImageName = windowsPath.Replace("\\", "/");
                IsSuccess = await _SliderService.SaveNew(Slider);
            }
            else
            {
                // Slider Updates may not update images
                if (File is not null)
                {
                    string windowsPath = await Utilities.FileUtility.SaveFile(File, "Images\\Sliders", [".jpg", ".jpeg", ".png"]);
                    Slider.ImageName = windowsPath.Replace("\\", "/");
                }
                IsSuccess = await _SliderService.SaveUpdate(Slider);
            }

            if (!IsSuccess)
            {
                return StatusCode(500, "A server side error occured while processing your request");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            string ImagePath = await _SliderService.RemoveSlider(id);

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
