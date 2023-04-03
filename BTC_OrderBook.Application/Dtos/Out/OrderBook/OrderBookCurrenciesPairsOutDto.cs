using BTC_OrderBook.Domain.Enums;

namespace BTC_OrderBook.Application.Dtos.Out.OrderBook
{

    /// <summary>
    /// Order book currency pair out dto
    /// </summary>
    public class OrderBookCurrencyPairOutDto
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
