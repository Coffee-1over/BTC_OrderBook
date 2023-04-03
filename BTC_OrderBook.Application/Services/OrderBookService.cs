using AutoMapper;
using BTC_OrderBook.Domain.Abstracts.Clients;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;
using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Exceptions;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;
using BTC_OrderBook.Domain.Services.Abstract;
using Microsoft.Extensions.Options;

namespace BTC_OrderBook.Application.Services
{
    /// <summary>
    /// Order book service
    /// </summary>
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderBookClient _orderBookClient;
        private readonly IMapper _mapper;
        private readonly IOrderBookRepository _orderBookRepository;
        public readonly BitstampOrderBookAdditionalInfoConfig _bitstampOrderBookAdditionalInfoConfig;

        /// <summary>
        /// Order book service Constructor
        /// </summary>
        /// <param name="orderBookClient">Order book client</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="orderBookRepository">Order book repository</param>
        /// <param name="bitstampOrderBookAdditionalInfoConfig">Bitstamp order book additional info config</param>
        public OrderBookService(IOrderBookClient orderBookClient,
                                IMapper mapper,
                                IOrderBookRepository orderBookRepository,
                                IOptions<BitstampOrderBookAdditionalInfoConfig> bitstampOrderBookAdditionalInfoConfig)
        {
            _orderBookClient = orderBookClient;
            _mapper= mapper;
            _orderBookRepository = orderBookRepository;
            _bitstampOrderBookAdditionalInfoConfig = bitstampOrderBookAdditionalInfoConfig.Value;
        }

        /// <inheritdoc />
        public IList<BitstampCurrenciesPairsConfig> CurrenciesPairs => _bitstampOrderBookAdditionalInfoConfig.CurrenciesPairs;


        /// <inheritdoc />
        public async Task<OrderBookClientModel> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken)
        {
            var orderBookClientModel = await _orderBookClient.GetOrderBookAsync(curreciesPair.ToString(), cancellationToken);

            if(orderBookClientModel == null)
            {
                throw new OrderBookException("");
            }

            var entity = _mapper.Map<OrderBookEntity>(orderBookClientModel);
            entity.CurreciesPair = curreciesPair;

            await _orderBookRepository.AddAsync(entity, cancellationToken);

            return orderBookClientModel;
        }
    }
}
