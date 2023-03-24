using BTC_OrderBook.Domain.Abstracts.Clients;
using BTC_OrderBook.Domain.Configs.Bitstamp;
using BTC_OrderBook.Domain.Constants;
using BTC_OrderBook.Domain.Exceptions;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace BTC_OrderBook.Infrastructure.Clients.OrderBook
{
    public class OrderBookClient : IOrderBookClient
    {
        private readonly BitstampConfig _config;
        private readonly HttpClient _httpClient;
        private readonly ILogger<OrderBookClient> _logger;
        public OrderBookClient(IOptions<BitstampConfig> config, ILogger<OrderBookClient> logger, HttpClient httpClient)
        {
            _config = config.Value;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<OrderBookClientModel> GetOrderBookAsync(string currenciesPair, CancellationToken cancellationToken)
        {
            var url = string.Format(_config.OrderBook.Link, currenciesPair);

            var result = await MakeGetRequestAsync(url, cancellationToken);

            return await result.Content.ReadFromJsonAsync<OrderBookClientModel>(JsonConstants.JsonSerializerOptions, cancellationToken);
        }
        private async Task<HttpResponseMessage> MakeGetRequestAsync(string url, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(content);
            throw new OrderBookException("SomethingWrong");
        }


    }

}
