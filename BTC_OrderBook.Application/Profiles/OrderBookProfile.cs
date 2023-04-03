using AutoMapper;
using BTC_OrderBook.Application.Dtos.Out.OrderBook;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;
using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Extensions;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;

namespace BTC_OrderBook.Application.Profiles
{
    /// <summary>
    /// Order book automapper profile
    /// </summary>
    public class OrderBookProfile : Profile
    {
        /// <summary>
        /// Order book automapper profile constructor
        /// </summary>
        public OrderBookProfile()
        {
            MapModelsAndDtos();
            MapModelsAndEntities();
        }

        /// <summary>
        /// Mapp models to enteties
        /// </summary>
        private void MapModelsAndEntities()
        {
            CreateMap<OrderBookClientModel, OrderBookEntity>()
                 .ForMember(entity => entity.TradeOrders, opt => opt.MapFrom(model => new List<TradeOrderEntity>())) 
                 .AfterMap((clientModel, entity) =>
                 {
                     AddExternalClientOrdersToEntity(entity.TradeOrders, clientModel.Asks, false);
                     AddExternalClientOrdersToEntity(entity.TradeOrders, clientModel.Bids, true);
                 })
                 .ForAllMembersIgnore(new[]
                 {
                     nameof(OrderBookEntity.Id),
                     nameof(OrderBookEntity.CurreciesPair)
                 });
        }

        /// <summary>
        /// Mapp models to dtos
        /// </summary>
        private void MapModelsAndDtos()
        {
            CreateMap<OrderBookClientModel, OrderBookOutDto>();
            CreateMap<BitstampCurrenciesPairsConfig, OrderBookCurrenciesPairsOutDto>();
        }

        /// <summary>
        /// Add from external client orders to entity list
        /// </summary>
        /// <param name="tradeOrderEntities">Entity list</param>
        /// <param name="externalClientModels">External client orders</param>
        /// <param name="isBuy">Is orders buy</param>
        private void AddExternalClientOrdersToEntity(IList<TradeOrderEntity> tradeOrderEntities, IList<IList<decimal>> externalClientModels, bool isBuy)
            => externalClientModels.ForEach(x => tradeOrderEntities.Add(new TradeOrderEntity
            {
                Amount = x[0],
                Price = x[1],
                IsBuy = isBuy,
            }));
    }
}
