using LapShop.Data.Repository;

namespace LapShop.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<Domains.Category>> PrepareDashboard() => await _UnitOfWork.Categories.GetAllAsync();

        public async Task<Domains.Category> GetTargetCategory(int id) => await _UnitOfWork.Categories.GetByIdAsync(id);

        public async Task<bool> SaveNew(Domains.Category Category)
        {
            try
            {
                Category.CategoryBy = "1";
                Category.CreatedDate = DateTime.Now;
                await _UnitOfWork.Categories.AddAsync(Category);
                await _UnitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SaveUpdate(Domains.Category Category)
        {
            try
            {
                Category.UpdatedBy = "1";
                Category.UpdatedDate = DateTime.Now;
                _UnitOfWork.Categories.Update(Category);
                await _UnitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> RemoveCategory(int id)
        {
            try
            {
                Domains.Category TargetCategory = await _UnitOfWork.Categories.GetByIdAsync(id);
                string TargetImage = TargetCategory.ImageName;
                if (TargetCategory is not null)
                {
                    if (!_UnitOfWork.Categories.Delete(TargetCategory))
                    {
                        // failed to delete in database
                        // log database error
                    }
                    await _UnitOfWork.CompleteAsync();
                    return TargetImage;
                }
                // we somehow passed an invalid id
                // TODO: Log this
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
