using ITC.DataAccess.Entities;
using ITC.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ITC.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        IDbContextTransaction BeginTransaction();

        Task SaveChangesAsync();
    }
}
