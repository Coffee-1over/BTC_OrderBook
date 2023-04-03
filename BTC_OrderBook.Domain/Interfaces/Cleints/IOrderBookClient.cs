

using BTC_OrderBook.Domain.Models.Clients.OrderBook;

namespace BTC_OrderBook.Domain.Abstracts.Clients
{
    public interface IOrderBookClient
    {
        /// <summary>
        /// Get order book async
        /// </summary>
        /// <param name="currenciesPair">Currencies pari for order book</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Order book</returns>
        Task<OrderBookClientModel?> GetOrderBookAsync(string currenciesPair, CancellationToken cancellationToken);
    }
}
