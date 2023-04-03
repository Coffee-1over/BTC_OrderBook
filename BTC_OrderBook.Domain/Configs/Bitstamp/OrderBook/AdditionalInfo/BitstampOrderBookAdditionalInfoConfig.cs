using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo
{
    /// <summary>
    /// Bitstamp order book additional info config
    /// </summary>
    public class BitstampOrderBookAdditionalInfoConfig
    {
        /// <summary>
        /// Bitstamp currencies pairs
        /// </summary>
        public IList<BitstampCurrencyPairConfig> CurrenciesPairs { get; set; } = null!; 
    }
}
