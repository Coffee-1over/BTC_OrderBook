using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Entities
{
    /// <summary>
    /// Trade order db entity
    /// </summary>
    [Table("TRADE_ORDERS")]
    public class TradeOrderEntity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Column("ID_TRADE_ORDER")]
        public long Id { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Column("PRICE")]
        public decimal Price { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Is buy order
        /// </summary>
        [Column("IS_BUY")]
        public bool IsBuy { get; set; }
    }
}
