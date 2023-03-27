using AutoMapper;
using BTC_OrderBook.Domain.Abstracts.Clients;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;
using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;
using BTC_OrderBook.Domain.Services.Abstract;
using Microsoft.Extensions.Options;

namespace BTC_OrderBook.Application.Services
{
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderBookClient _orderBookClient;
        private readonly IMapper _mapper;
        private readonly IOrderBookRepository _orderBookRepository;
        public readonly BitstampOrderBookAdditionalInfoConfig _bitstampOrderBookAdditionalInfoConfig;
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

        public IList<BitstampCurrenciesPairsConfig> CurrenciesPairs => _bitstampOrderBookAdditionalInfoConfig.CurrenciesPairs;

        public async Task<OrderBookClientModel> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken)
        {
            var orderBookClientModel = await _orderBookClient.GetOrderBookAsync(curreciesPair.ToString(), cancellationToken);

            var entity = _mapper.Map<OrderBookEntity>(orderBookClientModel);
            entity.CurreciesPair = curreciesPair;

            await _orderBookRepository.AddAsync(entity, cancellationToken);

            return orderBookClientModel;
        }
    }
}
