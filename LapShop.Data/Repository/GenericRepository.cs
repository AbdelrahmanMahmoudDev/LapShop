using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Data.Repository
{
    public class GenericRepository<Type> : IRepository<Type> where Type : class
    {
        private readonly MainContext _Context;
        private readonly DbSet<Type> _DbSet;

        public GenericRepository(MainContext Context)
        {
            _Context = Context;
            _DbSet = _Context.Set<Type>();
        }

        public async Task<Type> GetByIdAsync(int Id)
        {
            if (Id < 0)
            {
                throw new InvalidOperationException($"This Id: {Id} is invalid");
            }

            try
            {
                return await _DbSet.FindAsync(Id);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Type>> GetAllAsync() => await _DbSet.ToListAsync();

        public async Task<bool> AddAsync(Type Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            try
            {
                await _Context.AddAsync(Entity);
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }

        public bool Update(Type Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            try
            {
                _Context.Update(Entity);
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }

        public bool Delete(Type Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            try
            {
                _Context.Remove(Entity);
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
