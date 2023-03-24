using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Infrastructure.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BTC_OrderBook.Infrastructure.Contexts
{
    public class ApplicationContext : BaseDbContext
    {
        /// <summary>
        /// DB scheme
        /// </summary>
        public const string SchemaName = "BTC_OrderBook";

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        /// <summary>
        /// Calling all settings to model creating DB
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DisableCascadeDeletes();
            modelBuilder.SetEnumToStringConversion(32);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OrderBookEntity> OrderBooks { get; set; }
        public DbSet<TradeOrderEntity> TradeOrders { get; set; }
    }
}