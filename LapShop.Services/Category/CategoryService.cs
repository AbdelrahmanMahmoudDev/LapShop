using System.Diagnostics;
using LapShop.Data;
using LapShop.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly MainContext _MainContext;

        public CategoryService(MainContext mainContext)
        {
            _MainContext = mainContext;
        }

        public async Task<IEnumerable<Domains.Category>> PrepareDashboard()
        {
            try
            {
                return await Task.FromResult(_MainContext.Categories);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Domains.Category> GetTargetCategory(int id)
        {
            try
            {
                return await _MainContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> SaveNew(Domains.Category Category)
        {
            try
            {
                Category.CategoryBy = "1";
                Category.CreatedDate = DateTime.Now;

                await _MainContext.AddAsync(Category);
                await _MainContext.SaveChangesAsync();

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

                _MainContext.Update(Category);
                await _MainContext.SaveChangesAsync();

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
                Domains.Category TargetCategory =  await _MainContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

                string TargetImage = TargetCategory.ImageName;

                if (TargetCategory is not null)
                {
                    _MainContext.Remove(TargetCategory);
                    await _MainContext.SaveChangesAsync();

                    return TargetImage;
                }
                // we somehow passed an invalid id
                // TODO: Log this
                return null;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
