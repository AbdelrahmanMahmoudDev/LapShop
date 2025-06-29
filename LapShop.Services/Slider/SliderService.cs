using System.Diagnostics;
using LapShop.Data;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Services.Slider
{
    public class SliderService : ISliderService
    {
        private readonly MainContext _MainContext;

        public SliderService(MainContext mainContext)
        {
            _MainContext = mainContext;
        }

        public async Task<IEnumerable<Domains.Slider>> PrepareDashboard()
        {
            try
            {
                return await Task.FromResult(_MainContext.Sliders);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Domains.Slider> GetTargetSlider(int id)
        {
            try
            {
                return await _MainContext.Sliders.FirstOrDefaultAsync(c => c.SliderId == id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> SaveNew(Domains.Slider Slider)
        {
            try
            {
                await _MainContext.AddAsync(Slider);
                await _MainContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SaveUpdate(Domains.Slider Slider)
        {
            try
            {
                _MainContext.Update(Slider);
                await _MainContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> RemoveSlider(int id)
        {
            try
            {
                Domains.Slider TargetSlider =  await _MainContext.Sliders.FirstOrDefaultAsync(c => c.SliderId == id);

                string TargetImage = TargetSlider.ImageName;

                if (TargetSlider is not null)
                {
                    _MainContext.Remove(TargetSlider);
                    await _MainContext.SaveChangesAsync();

                    return TargetImage;
                }
                // we somehow passed an invalid id
                // TODO: Log this
                return null;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
