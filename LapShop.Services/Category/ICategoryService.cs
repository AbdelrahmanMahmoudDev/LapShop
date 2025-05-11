namespace LapShop.Services.Category
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Domains.Category>> PrepareDashboard();
        public Task<Domains.Category> GetTargetCategory(int id);
        public Task<bool> SaveNew(Domains.Category Category);
        public Task<bool> SaveUpdate(Domains.Category category);
        public Task<string> RemoveCategory(int id);
    }
}
