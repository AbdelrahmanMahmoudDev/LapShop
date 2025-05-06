using Microsoft.EntityFrameworkCore.Storage;
using Models.Repositories;

namespace LapShop.Models.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        ValueTask<IDbContextTransaction> BeginTransaction();
        Task<int> CompleteAsync();
    }
}
