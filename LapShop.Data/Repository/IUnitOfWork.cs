using Microsoft.EntityFrameworkCore.Storage;
using LapShop.Domains;
namespace LapShop.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        ValueTask<IDbContextTransaction> BeginTransaction();
        Task<int> CompleteAsync();
    }
}
