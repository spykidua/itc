using ITC.DataAccess.Entities;
using ITC.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITC.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        private DbContext Context { get; set; }

        private DbSet<TEntity> DbSet => Context.Set<TEntity>();

        public async Task<ICollection<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>> sorter = null,
            bool sortDescending = false,
            int? skip = null,
            int? take = null)
        {
            var query = Context.Set<TEntity>().AsNoTracking();

            var resultSet = filter == null 
                ? query
                : AssignPredicates(query, new List<Expression<Func<TEntity, bool>>> { filter });

            if (sorter != null)
            {
                resultSet = sortDescending
                    ? resultSet.OrderByDescending(sorter)
                    : resultSet.OrderBy(sorter);
            }

            if (skip.HasValue)
            {
                resultSet = resultSet.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                resultSet = resultSet.Take(take.Value);
            }

            return await resultSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<TEntity> AssignPredicates(IQueryable<TEntity> query, IList<Expression<Func<TEntity, bool>>> predicates)
        {
            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            return query;
        }
    }
}
