using ITC.DataAccess.Entities;
using System.Linq.Expressions;

namespace ITC.DataAccess.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<ICollection<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? sorter = null,
            int? skip = null,
            int? take = null);
    }
}
