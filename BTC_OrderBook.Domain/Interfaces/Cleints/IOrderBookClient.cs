

using BTC_OrderBook.Domain.Models.Clients.OrderBook;

namespace BTC_OrderBook.Domain.Abstracts.Clients
{
    public interface IOrderBookClient
    {
        Task<OrderBookClientModel> GetOrderBookAsync(string currenciesPair, CancellationToken cancellationToken);
    }
}
