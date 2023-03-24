using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTC_OrderBook.Domain.Entities
{
    [Table("ORDER_BOOKS")]
    public class OrderBookEntity
    {
        [Column("ID_ORDER_BOOK")]
        public long Id { get; set; }

        [Column("TIMESTAMP")]
        public long Timestamp { get; set; }

        public IList<TradeOrderEntity> Asks { get; set; }
        public IList<TradeOrderEntity> Bids { get; set; }
    }
}
