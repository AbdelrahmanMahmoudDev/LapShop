
using LapShop.Models;
using LapShop.Models.Repositories.Base;

namespace LapShop.BL
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<Category>> PrepareDashboard()
        {
            return await _UnitOfWork.Categories.GetAll();
        }
    }
}
