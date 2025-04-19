using LapShop.Models;

namespace LapShop.BL
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> PrepareDashboard();
    }
}
