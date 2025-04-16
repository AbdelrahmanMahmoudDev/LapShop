using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Models.Repositories;

namespace LapShop.Models.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly MainContext _Context;
        public CategoryRepository(MainContext Context)
        {
            _Context = Context ?? throw new ArgumentNullException(nameof(Context));
        }
        public async Task<bool> Create(Category obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            try
            {
                await _Context.AddAsync(obj);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }

        public async Task<bool> Delete(Category obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            try
            {
                _Context.Remove(obj);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _Context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAll(List<string> NavProps)
        {
            if(NavProps == null)
            {
                throw new ArgumentNullException(nameof(NavProps));
            }

            try
            {
                IQueryable<Category> Collection = _Context.Categories;
                foreach (var Prop in NavProps)
                {
                    if (string.IsNullOrWhiteSpace(Prop))
                    {
                        continue;
                    }
                    Collection = Collection.Include(Prop);
                }

                return await Collection.ToListAsync();
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }

        public async Task<Category> GetById(int id)
        {
            if(id < 0)
            {
                throw new InvalidOperationException($"This Id: {id} is invalid");
            }

            try
            {
                return await _Context.Categories.FindAsync(id);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }

        public async Task<Category> GetById(int id, List<string> NavProps)
        {
            if(id < 0)
            {
                throw new InvalidOperationException($"This Id: {id} is invalid");
            }
            if (NavProps == null)
            {
                throw new ArgumentNullException(nameof(NavProps));
            }

            try
            {
                IQueryable<Category> Collection = _Context.Categories;
                foreach (var Prop in NavProps)
                {
                    if (string.IsNullOrWhiteSpace(Prop))
                    {
                        continue;
                    }
                    Collection = Collection.Include(Prop);
                }

                return await Collection.FirstOrDefaultAsync(c => c.CategoryId == id);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetBySubString(string SubString)
        {
            if (string.IsNullOrWhiteSpace(SubString))
            {
                throw new ArgumentNullException("Substring cannot be null or empty.", nameof(SubString));
            }

            try
            {
                IQueryable<Category> Collection = _Context.Categories.Where(c => c.CategoryName.Contains(SubString, StringComparison.OrdinalIgnoreCase));
                return await Collection.ToListAsync();
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetBySubString(string SubString, List<string> NavProps)
        {
            if(string.IsNullOrWhiteSpace(SubString))
            {
                throw new ArgumentNullException("Substring cannot be null or empty.", nameof(SubString));
            }
            if (NavProps == null)
            {
                throw new ArgumentNullException(nameof(NavProps));
            }

            try
            {
                IQueryable<Category> Collection = _Context.Categories;
                foreach (var Prop in NavProps)
                {
                    if (string.IsNullOrWhiteSpace(Prop))
                    {
                        continue;
                    }
                    Collection = Collection.Include(Prop);
                }

                Collection =  Collection.Where(c => c.CategoryName.Contains(SubString, StringComparison.OrdinalIgnoreCase));
                return await Collection.ToListAsync();
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }

        public async Task<bool> Update(Category obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            try
            {
                Category Target = await _Context.Categories.FindAsync(obj.CategoryId);
                if(Target == null)
                {
                    return false;
                }

                _Context.Update(obj);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }
    }
}
