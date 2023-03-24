using AutoMapper;
using BTC_OrderBook.Domain.Exceptions;
using BTC_OrderBook.Domain.Extensions.Includes;
using BTC_OrderBook.Infrastructure.Contexts;
using BTC_OrderBook.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace BTC_OrderBook.Infrastructure.Repository.Abstract
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Logger
        /// </summary>
        protected ILogger Logger { get; }

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
        public BaseRepository(ApplicationContext context, ILogger logger, IMapper mapper)
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

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
            => HandleAsync((dbContext, cToken) =>
                dbContext.Set<TEntity>().AsQueryable().AnyAsync(predicate, cToken), cancellationToken);

        public virtual Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken,
            Func<IIncludable<TEntity>, IIncludable> includes = default)
            => HandleAsync(async (dbContext, cToken) =>
            {
                var query = dbContext.Set<TEntity>().AsQueryable().AsNoTracking();

                query = query.IncludeMultiple(includes);

                var entity = await query.FirstOrDefaultAsync(predicate, cToken);

                if (entity is null)
                {
                    return default;
                }

                return entity;
            }, cancellationToken);

        public virtual Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken, Func<IIncludable<TEntity>, IIncludable> includes = default)
            => HandleAsync(async (dbContext, cToken) =>
            {
                var query = dbContext.Set<TEntity>().AsQueryable().AsNoTracking();

                query = query.IncludeMultiple(includes);

                if (predicate is not null)
                {
                    query = query.Where(predicate);
                }

                var entities = await query.ToListAsync(cToken);

                if (entities.Count == 0)
                {
                    return Array.Empty<TEntity>();
                }

                return Mapper.Map<IList<TEntity>>(entities);
            }, cancellationToken);

        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
            => SaveChangesAndHandleExceptionAsync<TEntity>(async (dbContext, cToken) =>
            {
                var result = await dbContext.Set<TEntity>().AddAsync(entity, cToken);
                return () =>
                {
                    dbContext.DetachAll();
                    return result.Entity;
                };
            }, cancellationToken);

        public virtual Task AddRangeAsync(IList<TEntity> models, CancellationToken cancellationToken)
            => SaveChangesAndHandleExceptionAsync<Task>(async (dbContext, cToken) =>
            {
                var entites = Mapper.Map<IEnumerable<TEntity>>(models);
                await dbContext.Set<TEntity>().AddRangeAsync(entites, cToken);
                return () => Task.CompletedTask;
            }, cancellationToken);

        public virtual Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken)
            => SaveChangesAndHandleExceptionAsync<TEntity>(async (dbContext, cToken) =>
            {
                var entity = Mapper.Map<TEntity>(model);
                dbContext.Entry(entity).State = EntityState.Modified;
                var result = dbContext.Set<TEntity>().Update(entity);

                return () =>
                {
                    dbContext.DetachAll();
                    return result.Entity;
                };
            }, cancellationToken);

        public virtual Task<TEntity> UpdatePartiallyAsync(TEntity entity, IEnumerable<string> updatedProperties, CancellationToken cancellationToken)
            => SaveChangesAndHandleExceptionAsync<TEntity>(async (dbContext, cToken) =>
            {

                var keyNames = dbContext.Model
                    .FindEntityType(typeof(TEntity))
                    .FindPrimaryKey().Properties
                    .Select(x => x.Name);

                updatedProperties.ForEach(item =>
                {
                    if (!keyNames.Contains(item))
                    {
                        dbContext.Entry(entity).Property(item).IsModified = true;
                    }
                });

                return () => entity;
            }, cancellationToken);

        public virtual Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
            => SaveChangesAndHandleExceptionAsync<bool>(async (dbContext, cToken) =>
            {
                dbContext.Set<TEntity>().Remove(entity);
                return () => true;
            }, cancellationToken);

    }
}