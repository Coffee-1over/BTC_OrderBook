using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Infrastructure.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BTC_OrderBook.Infrastructure.Contexts
{
    /// <summary>
    /// Application context
    /// </summary>
    public class ApplicationContext : BaseDbContext
    {
        /// <summary>
        /// DB scheme
        /// </summary>
        public const string SchemaName = "BTC_OrderBook";

        /// <summary>
        /// Application context constructor
        /// </summary>
        /// <param name="options">Application context options</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        /// <summary>
        /// Calling all settings to model creating DB
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);
            modelBuilder.DisableCascadeDeletes();
            modelBuilder.SetEnumToStringConversion(32);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Order book entity
        /// </summary>
        public DbSet<OrderBookEntity> OrderBooks { get; set; }

        /// <summary>
        /// Trade orders entity
        /// </summary>
        public DbSet<TradeOrderEntity> TradeOrders { get; set; }
    }
}