using BTC_OrderBook.Domain.Enums;

namespace BTC_OrderBook.Application.Dtos.Out.OrderBook
{
    public class OrderBookCurrenciesPairsOutDto
    {
        public string View { get; set; }
        public OrderBookCurreciesPair Value { get; set; }
    }
}
