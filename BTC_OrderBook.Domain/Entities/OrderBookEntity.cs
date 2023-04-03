using BTC_OrderBook.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTC_OrderBook.Domain.Entities
{
    /// <summary>
    /// Order book db entity
    /// </summary>
    [Table("ORDER_BOOKS")]
    public class OrderBookEntity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Column("ID_ORDER_BOOK")]
        public long Id { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [Column("TIMESTAMP")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Currecies Order book pair
        /// </summary>
        [Column("CURRENCIES_PAIR")]
        public OrderBookCurreciesPair CurreciesPair { get; set; }

        /// <summary>
        /// Trade orders
        /// </summary>
        public IList<TradeOrderEntity> TradeOrders { get; set; } = null!;
    }
}
