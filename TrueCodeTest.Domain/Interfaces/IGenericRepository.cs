using System.Linq.Expressions;
using TrueCodeTest.Domain.Entities.Abstractions;

namespace TrueCodeTest.Domain.Interfaces
{
    public interface IGenericRepository<TKey, TEntity> where TEntity : EntityBase<TKey> 
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IEnumerable<string> includeProperties = null);

        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            IEnumerable<string> includedProperties = null);

        Task<TKey> AddAsync(TEntity entity);

        Task<TKey> UpdateAsync(TEntity entity);

        Task<TKey> Delete(TEntity entity);
    }
}
