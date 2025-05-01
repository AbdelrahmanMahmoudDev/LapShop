using LapShop.Models;

namespace LapShop.BL
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> PrepareDashboard();
        public Task<Category> GetTargetCategory(int id);
        public Task<bool> SaveNew(Category Category);
        public Task<bool> SaveUpdate(Category Category);
        public Task<bool> RemoveCategory(int id);
    }
}
