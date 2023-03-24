using AutoMapper;
using BTC_OrderBook.Controller.Abstract;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTC_OrderBook.Controller
{
    public class OrderBookController : BaseControllerApi
    {
        private readonly IOrderBookService _orderBookService;
        public OrderBookController(ILogger<OrderBookController> logger, IMapper mapper, IOrderBookService orderBookService) : base(logger, mapper)
        {
            _orderBookService = orderBookService;
        }

        [AllowAnonymous]
        [HttpGet("{curreciesPair}")]
        public async Task<IActionResult> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken)
        {
            var result = await _orderBookService.GetOrderBookAsync(curreciesPair, cancellationToken);
            return MakeResponse(result);
        }
    }
}
