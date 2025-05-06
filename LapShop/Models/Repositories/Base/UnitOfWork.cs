using Microsoft.EntityFrameworkCore.Storage;
using Models.Repositories;

namespace LapShop.Models.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _Context;
        public IRepository<Category> Categories { get; private set; }
        public UnitOfWork(MainContext Context)
        {
            _Context = Context;
            Categories = new GenericRepository<Category>(_Context);
        }

        public async ValueTask<IDbContextTransaction> BeginTransaction() => await _Context.Database.BeginTransactionAsync();
        public async Task<int> CompleteAsync() => await _Context.SaveChangesAsync();
        public void Dispose() => _Context.Dispose();
    }
}
