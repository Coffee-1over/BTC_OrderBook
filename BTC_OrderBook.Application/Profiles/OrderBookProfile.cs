using AutoMapper;
using BTC_OrderBook.Application.Dtos.Out.OrderBook;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;
using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Extensions;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;

namespace BTC_OrderBook.Application.Profiles
{
    public class OrderBookProfile : Profile
    {
        public OrderBookProfile()
        {
            MapModelsAndDtos();
            MapModelsAndEntities();
        }


        private void MapModelsAndEntities()
        {
            CreateMap<OrderBookClientModel, OrderBookEntity>()
                 .ForMember(entity => entity.Asks, opt => opt.MapFrom(model => model.Asks.Select(x => new TradeOrderEntity
                 {
                     Amount = x[0],
                     Price = x[1],
                     IsBuy = false,
                 })))
                 .ForMember(entity => entity.Bids, opt => opt.MapFrom(model => model.Bids.Select(x => new TradeOrderEntity
                 {
                     Amount = x[0],
                     Price = x[1],
                     IsBuy = true,
                 })))
                 .ForAllMembersIgnore(new[]
                 {
                     nameof(OrderBookEntity.Id),
                     nameof(OrderBookEntity.CurreciesPair)
                 });
        }

        private void MapModelsAndDtos()
        {
            CreateMap<OrderBookClientModel, OrderBookOutDto>();
            CreateMap<BitstampCurrenciesPairsConfig, OrderBookCurrenciesPairsOutDto>();
        }
    }
}
