using ITC.DataAccess.Entities;
using System.Linq.Expressions;

namespace ITC.DataAccess.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>> sorter = null,
            bool sortDescending = false,
            int? skip = null,
            int? take = null);
    }
}
