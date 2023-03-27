using BTC_OrderBook.Domain.Enums;

namespace BTC_OrderBook.Application.Dtos.Out.OrderBook
{
    public class OrderBookOutDto
    {
        public long Timestamp { get; set; }
        public IList<IList<decimal>> Bids { get; set; }
        public IList<IList<decimal>> Asks { get; set; }
    }
}
