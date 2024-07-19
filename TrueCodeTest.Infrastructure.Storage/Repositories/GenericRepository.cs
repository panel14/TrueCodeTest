using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrueCodeTest.Domain.Entities.Abstractions;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Infrastructure.Repositories
{
    public abstract class GenericRepository<TKey, TEntity>(DbContext context)
        : IGenericRepository<TKey, TEntity> where TEntity
        : EntityBase<TKey> where TKey : notnull
    {
        private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public async Task<TKey> AddAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity.Id;
        }

        public async Task<TKey> Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            return entity.Id;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IEnumerable<string> includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            IEnumerable<string> includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            var result = await query.SingleOrDefaultAsync();
            return result;
        }

        public async Task<TKey> UpdateAsync(TEntity entity)
        {
            var result = _dbSet.Update(entity);
            return result.Entity.Id;
        }
    }
}
