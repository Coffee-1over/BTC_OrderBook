namespace BTC_OrderBook.Domain.Models.Clients.OrderBook
{
    /// <summary>
    /// Order book client model
    /// </summary>
    public class OrderBookClientModel
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
