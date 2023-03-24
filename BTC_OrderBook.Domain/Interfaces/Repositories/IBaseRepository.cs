using BTC_OrderBook.Domain.Extensions.Includes;
using System.Linq.Expressions;

namespace BTC_OrderBook.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken);

        Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken,
            Func<IIncludable<TEntity>, IIncludable> includes = default);

        Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken,
            Func<IIncludable<TEntity>, IIncludable> includes = default);

        Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken);

        Task AddRangeAsync(IList<TEntity> models, CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken);

        Task<TEntity> UpdatePartiallyAsync(TEntity model, IEnumerable<string> updatedProperties, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}