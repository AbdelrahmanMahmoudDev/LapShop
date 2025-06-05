using LapShop.Domains.ViewModels;   

namespace LapShop.Services.Item
{
    public interface IItemService
    {
        public IQueryable<VwItemsVM> PrepareDashboard(string searchValue);
        public VwItemsVM GetSingle(int? id);
        public Task Save(VwItemsVM itemVM);
        public Task Delete(int id);
        public HomepageVM PrepareHomepage(HomepageVM homepageVM = null);
    }
}
