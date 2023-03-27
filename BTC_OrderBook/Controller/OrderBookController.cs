using AutoMapper;
using BTC_OrderBook.Application.Dtos.Out.OrderBook;
using BTC_OrderBook.Controller.Abstract;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace BTC_OrderBook.Controller
{
    [AllowAnonymous]
    public class OrderBookController : BaseControllerApi
    {
        private readonly IOrderBookService _orderBookService;
        public OrderBookController(ILogger<OrderBookController> logger, IMapper mapper, IOrderBookService orderBookService) : base(logger, mapper)
        {
            _orderBookService = orderBookService;
        }

        [HttpGet("currecies-pairs")]
        public IActionResult GetCurrenciesPairs()
        {
            var outDto = Mapper.Map<IList<OrderBookCurrenciesPairsOutDto>>(_orderBookService.CurrenciesPairs);
            return MakeResponse(outDto);
        }

        [HttpGet("{curreciesPair}")]
        public async Task<IActionResult> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken)
        {
            var result = await _orderBookService.GetOrderBookAsync(curreciesPair, cancellationToken);
            var outDto = Mapper.Map<OrderBookOutDto>(result);
            return MakeResponse(outDto);
        }
    }
}
