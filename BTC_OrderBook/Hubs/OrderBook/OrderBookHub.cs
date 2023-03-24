/*
using Bitstamp.Client.Websocket.Communicator;
using Bitstamp.Client.Websocket.Responses.Books;
using BTC_OrderBook.Domain.Configs.Hub;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Hubs.OrderBookHub;
using BTC_OrderBook.Infrastructure.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System.Linq;

namespace BTC_OrderBook.Hubs.OrderBook
{

    [AllowAnonymous]
    public class OrderBookHub : Hub
    {
        private readonly OrderBookHubConfig _hubConfig;
        private readonly IBitstampCommunicator _bitstampCommunicator;
        private readonly OrderBookClient _websocketOrderBookExternalProvider;
        private readonly ILogger<OrderBookHub> _logger;

        public OrderBookHub(IOptions<HubConfig> hubConfig, IServiceProvider serviceProvider)
        {
            _hubConfig = hubConfig.Value.OrderBookHub;

            var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope()
                ?? throw new InvalidOperationException($"{nameof(IServiceScopeFactory)} cannot be null.");

            _bitstampCommunicator = scope.ServiceProvider.GetRequiredService<IBitstampCommunicator>();
            _websocketOrderBookExternalProvider = scope.ServiceProvider.GetRequiredService<OrderBookClient>();
            _logger = scope.ServiceProvider.GetRequiredService<ILogger<OrderBookHub>>();
        }
        public async Task SendMessage(string curreciesPair)
        {
            await OrderBookProcessingAsync(Context.ConnectionId, Enum.Parse<OrderBookCurreciesPair>(curreciesPair), Context.ConnectionAborted);
        }

        private async Task OrderBookProcessingAsync(string connectionId, OrderBookCurreciesPair orderBookCurreciesPair, CancellationToken cancellationToken)
        {
            var orderBook = new OrderBookHubModel();

            await ConnectToBitstampAsync(orderBookCurreciesPair, orderBook);

           
            *//*await Clients.Client(connectionId).SendAsync(_hubConfig.MessageName, WebsocketOrderBookExternalClient.OrderBookHubEur, cancellationToken);
            await Task.Delay(TimeSpan.FromSeconds(_hubConfig.DelayInSeconds), Context.ConnectionAborted);*//*
        }


       
        private async Task ConnectToBitstampAsync(OrderBookCurreciesPair orderBookCurreciesPair, OrderBookHubModel orderBook)
        {
           *//* _websocketOrderBookExternalProvider.SubscribeToOrderBookStreams(orderBook);
            _bitstampCommunicator.ReconnectionHappened.Subscribe(async type =>
            {
                _logger.LogDebug($"Reconnection happened, type: {type.Type}, resubscribing..");
                _websocketOrderBookExternalProvider.SendOrderBookPairSubscriptionRequests(orderBookCurreciesPair);
            });

            await _bitstampCommunicator.Start();*//*
        }


        public Task OnDisconnectedAsync(Exception? exception)
        {
            Context.Abort();
            return Task.CompletedTask;
        }
    }
}

*/