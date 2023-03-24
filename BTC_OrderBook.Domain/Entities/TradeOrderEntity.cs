using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Entities
{
    [Table("TRADE_ORDERS")]
    public class TradeOrderEntity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Column("ID_TRADE_ORDER")]
        public long Id { get; set; }

        [Column("PRICE")]
        public decimal Price { get; set; }

        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        [Column("IS_BUY")]
        public bool IsBuy { get; set; }
    }
}
