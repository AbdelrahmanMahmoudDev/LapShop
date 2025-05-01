using Microsoft.EntityFrameworkCore.Storage;
using Models.Repositories;

namespace LapShop.Models.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _Context;
        public UnitOfWork(MainContext Context)
        {
            _Context = Context;
            Categories = new CategoryRepository(_Context);
        }
        public IRepository<Category> Categories { get; private set; }

        public async ValueTask<IDbContextTransaction> BeginTransaction()
        {
            return await _Context.Database.BeginTransactionAsync();
        }

        public MainContext GetContext()
        {
            return _Context;
        }
    }
}
