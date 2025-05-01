using LapShop.Models;

namespace LapShop.BL
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> PrepareDashboard();
        public Task<Category> GetTargetCategory(int id);
        public Task<bool> SaveNew(Category Category, IFormFile File);
        public Task<bool> SaveUpdate(Category category, IFormFile File);
        public Task<bool> RemoveCategory(int id);
    }
}
