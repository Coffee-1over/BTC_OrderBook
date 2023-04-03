
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook;

namespace BTC_OrderBook.Domain.Configs.Bitstamp
{
    /// <summary>
    /// Bitstamp config
    /// </summary>
    public class BitstampConfig
    {
        /// <summary>
        /// Api url
        /// </summary>
        public string ApiUrl { get; set; } = null!;

        /// <summary>
        /// Bitstamp order book config
        /// </summary>
        public BitstampOrderBookConfig OrderBook { get; set; } = null!;
    }
}
