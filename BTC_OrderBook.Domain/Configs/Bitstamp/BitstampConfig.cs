
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook;

namespace BTC_OrderBook.Domain.Configs.Bitstamp
{
    public class BitstampConfig
    {
        public string ApiUrl { get; set; }
        public BitstampOrderBookConfig OrderBook { get; set; }
    }
}
