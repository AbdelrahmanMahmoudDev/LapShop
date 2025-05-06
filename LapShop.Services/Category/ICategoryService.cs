namespace LapShop.Services.Category
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Data.Models.Category>> PrepareDashboard();
        public Task<Data.Models.Category> GetTargetCategory(int id);
        public Task<bool> SaveNew(Data.Models.Category Category);
        public Task<bool> SaveUpdate(Data.Models.Category category);
        public Task<string> RemoveCategory(int id);
    }
}
