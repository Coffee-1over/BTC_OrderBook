using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;

namespace BTC_OrderBook.Domain.Services.Abstract
{
    /// <summary>
    /// Intrface of order book service
    /// </summary>
    public interface IOrderBookService
    {
        /// <summary>
        /// Get order book
        /// </summary>
        /// <param name="curreciesPair"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Order book</returns>
        Task<OrderBookClientModel> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken);

        /// <summary>
        /// List of order book currencies pairs
        /// </summary>
        IList<BitstampCurrencyPairConfig> CurrenciesPairs { get; }
    }
}
