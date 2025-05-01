using Microsoft.EntityFrameworkCore.Storage;
using Models.Repositories;

namespace LapShop.Models.Repositories.Base
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get;  }

        ValueTask<IDbContextTransaction> BeginTransaction();

        MainContext GetContext();
    }
}
