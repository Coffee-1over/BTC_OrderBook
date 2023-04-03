using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;

namespace BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook
{
    /// <summary>
    /// Bitstamp order book config
    /// </summary>
    public class BitstampOrderBookConfig
    {
        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; } = null!;

        /// <summary>
        /// Bitstamp order book additional info
        /// </summary>
        public BitstampOrderBookAdditionalInfoConfig AdditionalInfo { get; set; } = null!;
    }
}
