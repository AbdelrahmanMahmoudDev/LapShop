using Microsoft.EntityFrameworkCore.Storage;
using LapShop.Data.Models;
namespace LapShop.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        ValueTask<IDbContextTransaction> BeginTransaction();
        Task<int> CompleteAsync();
    }
}
