using BTC_OrderBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo
{
    /// <summary>
    /// Bitstamp currency pair config
    /// </summary>
    public class BitstampCurrencyPairConfig
    {
        /// <summary>
        /// View variant of pair
        /// </summary>
        public string View { get; set; } = null!;

        /// <summary>
        /// Enum value
        /// </summary>
        public OrderBookCurreciesPair Value { get; set; }
    }
}
