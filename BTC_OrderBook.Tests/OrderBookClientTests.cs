using System.Net;
using BTC_OrderBook.Domain.Configs.Bitstamp;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Exceptions;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;
using BTC_OrderBook.Infrastructure.Clients.OrderBook;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace BTC_OrderBook.Tests
{
    [TestFixture]
    public class OrderBookClientTests
    {
        private Mock<IOptions<BitstampConfig>> _configMock;
        private Mock<ILogger<OrderBookClient>> _loggerMock;
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _configMock = new Mock<IOptions<BitstampConfig>>();
            _loggerMock = new Mock<ILogger<OrderBookClient>>();
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        }

        [Test]
        public async Task GetOrderBookAsync_ShouldReturnOrderBookClientModel_WhenSuccessful()
        {
            // Arrange
            var config = new BitstampConfig
            {
                ApiUrl = "https://test-api-url.com",
                OrderBook = new BitstampOrderBookConfig { Link = "test-link/{0}" }
            };
            _configMock.Setup(x => x.Value).Returns(config);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"timestamp\": 1234567890, \"bids\": [], \"asks\": [] }")
            };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object) { BaseAddress = new Uri(config.ApiUrl) };
            var orderBookClient = new OrderBookClient(_configMock.Object, _loggerMock.Object, httpClient);

            // Act
            var result = await orderBookClient.GetOrderBookAsync(OrderBookCurreciesPair.btcusd.ToString(), CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OrderBookClientModel>(result);
            Assert.IsEmpty(result.Bids);
            Assert.IsEmpty(result.Asks);
        }

        [Test]
        public void GetOrderBookAsync_ShouldThrowOrderBookException_WhenUnsuccessful()
        {
            // Arrange
            var config = new BitstampConfig
            {
                ApiUrl = "https://test-api-url.com",
                OrderBook = new  BitstampOrderBookConfig { Link = "test-link/{0}" }
            };
            _configMock.Setup(x => x.Value).Returns(config);

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("Error message")
            };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object) { BaseAddress = new Uri(config.ApiUrl) };
            var orderBookClient = new OrderBookClient(_configMock.Object, _loggerMock.Object, httpClient);

            // Act & Assert
            Assert.ThrowsAsync<OrderBookException>(async () => await orderBookClient.GetOrderBookAsync(OrderBookCurreciesPair.btcusd.ToString(), CancellationToken.None));
        }
    }
}