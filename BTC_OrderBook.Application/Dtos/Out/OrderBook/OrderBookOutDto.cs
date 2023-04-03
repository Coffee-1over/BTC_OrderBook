using BTC_OrderBook.Domain.Enums;

namespace BTC_OrderBook.Application.Dtos.Out.OrderBook
{
    /// <summary>
    /// Order book out dto
    /// </summary>
    public class OrderBookOutDto
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Bids(buy orders)
        /// </summary>
        public IList<IList<decimal>> Bids { get; set; } = null!;

        /// <summary>
        /// Asks(sell orders)
        /// </summary>
        public IList<IList<decimal>> Asks { get; set; } = null!;
    }
}
