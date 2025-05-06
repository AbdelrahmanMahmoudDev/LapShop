
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

        public async Task<IEnumerable<Category>> PrepareDashboard() => await _UnitOfWork.Categories.GetAllAsync();

        public async Task<Category> GetTargetCategory(int id) => await _UnitOfWork.Categories.GetByIdAsync(id);

        public async Task<bool> SaveNew(Category Category, IFormFile File)
        {
            try
            {
                Category.CategoryBy = "1";
                Category.CreatedDate = DateTime.Now;
                Category.ImageName = await Utilities.FileUtility.SaveFile(File, "Images\\Categories", [".jpg", ".jpeg", ".png"]);
                await _UnitOfWork.Categories.AddAsync(Category);
                await _UnitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SaveUpdate(Category Category, IFormFile File)
        {
            try
            {
                Category.UpdatedBy = "1";
                Category.UpdatedDate = DateTime.Now;

                // Category Updates may not update images
                if (File is not null)
                {
                    Category.ImageName = await Utilities.FileUtility.SaveFile(File, "Images\\Categories", [".jpg", ".jpeg", ".png"]);
                }
                _UnitOfWork.Categories.Update(Category);
                await _UnitOfWork.CompleteAsync();
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
                Category TargetCategory = await _UnitOfWork.Categories.GetByIdAsync(id);

                if (TargetCategory is not null)
                {
                    Utilities.FileUtility.DeleteFile(TargetCategory.ImageName);
                    if (!_UnitOfWork.Categories.Delete(TargetCategory))
                    {
                        // failed to delete in database
                        // log database error
                    }
                    await _UnitOfWork.CompleteAsync();
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
