using BTC_OrderBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Order book repository
    /// </summary>
    public interface IOrderBookRepository
    {
        /// <summary>
        /// Get by func one async
        /// </summary>
        /// <param name="predicate">Func for searching</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Entity</returns>
        Task<OrderBookEntity?> GetOneAsync(
          Expression<Func<OrderBookEntity, bool>> predicate,
          CancellationToken cancellationToken);

        /// <summary>
        /// Get by func async
        /// </summary>
        /// <param name="predicate">Func for searching entities</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of entities</returns>
        Task<IList<OrderBookEntity>> GetAsync(
            Expression<Func<OrderBookEntity, bool>> predicate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Add Order book entity
        /// </summary>
        /// <param name="model">Entity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Db entity</returns>
        Task<OrderBookEntity> AddAsync(OrderBookEntity model, CancellationToken cancellationToken);
    }
}
