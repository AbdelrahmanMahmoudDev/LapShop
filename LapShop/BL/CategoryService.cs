
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

        public async Task<Category> GetTargetCategory(int id)
        {
            return await _UnitOfWork.Categories.GetById(id);
        }

        public async Task<bool> SaveNew(Category Category)
        {
            try
            {
                Category.CategoryBy = "1";
                Category.CreatedDate = DateTime.Now;
                Category.ImageName = "";
                await _UnitOfWork.Categories.Create(Category);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SaveUpdate(Category Category)
        {
            try
            {
                Category.UpdatedBy = "1";
                Category.UpdatedDate = DateTime.Now;
                Category.ImageName = "";
                _UnitOfWork.GetContext().Entry(Category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _UnitOfWork.GetContext().SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveCategory(int id)
        {
            try
            {
                Category TargetCategory = await _UnitOfWork.Categories.GetById(id);

                if(TargetCategory is not null)
                {
                    if(! await _UnitOfWork.Categories.Delete(TargetCategory))
                    {
                        // failed to delete in database
                        // log database error
                    }
                    return true;
                }
                // we somehow passed an invalid id
                // TODO: Log this
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
