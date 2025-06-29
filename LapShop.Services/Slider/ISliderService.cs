namespace LapShop.Services.Slider
{
    public interface ISliderService
    {
        public Task<IEnumerable<Domains.Slider>> PrepareDashboard();
        public Task<Domains.Slider> GetTargetSlider(int id);
        public Task<bool> SaveNew(Domains.Slider Slider);
        public Task<bool> SaveUpdate(Domains.Slider Slider);
        public Task<string> RemoveSlider(int id);
    }
}
