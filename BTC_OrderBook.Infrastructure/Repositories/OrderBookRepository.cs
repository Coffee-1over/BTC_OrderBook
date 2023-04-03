using AutoMapper;
using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Exceptions;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using BTC_OrderBook.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BTC_OrderBook.Infrastructure.Repositories
{
    public class OrderBookRepository :  IOrderBookRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Logger
        /// </summary>
        protected ILogger<OrderBookRepository> Logger { get; }

        /// <summary>
        /// Mapper
        /// </summary>
        protected IMapper Mapper { get; }

        /// <summary>
        /// Base repository constructor
        /// </summary>
        /// <param name="context">Fabric data context</param>
        /// <param name="logger">Logger</param>
        /// <param name="mapper">Mapper</param>
        public OrderBookRepository(ApplicationContext context, ILogger<OrderBookRepository> logger, IMapper mapper)
        {
            Mapper = mapper;
            _context = context;
            Logger = logger;
        }

        /// <summary>
        /// Work with context db (with save) and user with catch exception
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="func">Action inside context</param>
        /// <param name="cancellationToken">Cancel token</param>
        /// <returns>Result</returns>
        protected Task<T> SaveChangesAndHandleExceptionAsync<T>(Func<ApplicationContext, CancellationToken, Task<Func<T>>> func, CancellationToken cancellationToken)
            => HandleAsync(async (dbContext, cToken) =>
            {
                var afterSaveFunc = await func(dbContext, cToken);
                await dbContext.SaveChangesAsync(cToken);
                return afterSaveFunc();
            }, cancellationToken);


        /// <summary>
        /// Work with context db with catch exception
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="func">Action inside context</param>
        /// <param name="cancellationToken">Cancel token</param>
        /// <returns>Result</returns>
        protected async Task<T> HandleAsync<T>(
            Func<ApplicationContext, CancellationToken, Task<T>> func,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await func(_context, cancellationToken);
                return result;
            }
            catch (DbUpdateException e)
            {
                Logger.LogError(e, "DbUpdateException error");
                throw new OrderBookException(e.Message, e);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Exception error");
                throw;
            }
        }

        public virtual Task<OrderBookEntity?> GetOneAsync(Expression<Func<OrderBookEntity, bool>> predicate, CancellationToken cancellationToken)
            => HandleAsync(async (dbContext, cToken) =>
            {
                var query = dbContext.Set<OrderBookEntity>().AsQueryable().AsNoTracking();

                var entity = await query.FirstOrDefaultAsync(predicate, cToken);

                if (entity is null)
                {
                    return default;
                }

                return entity;
            }, cancellationToken);

        public virtual Task<IList<OrderBookEntity>> GetAsync(Expression<Func<OrderBookEntity, bool>>? predicate, CancellationToken cancellationToken)
            => HandleAsync(async (dbContext, cToken) =>
            {
                var query = dbContext.Set<OrderBookEntity>().AsQueryable().AsNoTracking();

                if (predicate is not null)
                {
                    query = query.Where(predicate);
                }

                var entities = await query.ToListAsync(cToken);

                if (entities.Count == 0)
                {
                    return Array.Empty<OrderBookEntity>();
                }

                return Mapper.Map<IList<OrderBookEntity>>(entities);
            }, cancellationToken);

        public virtual Task<OrderBookEntity> AddAsync(OrderBookEntity entity, CancellationToken cancellationToken)
            => SaveChangesAndHandleExceptionAsync<OrderBookEntity>(async (dbContext, cToken) =>
            {
                var result = await dbContext.Set<OrderBookEntity>().AddAsync(entity, cToken);
                return () =>
                {
                    dbContext.DetachAll();
                    return result.Entity;
                };
            }, cancellationToken);
    }
}
