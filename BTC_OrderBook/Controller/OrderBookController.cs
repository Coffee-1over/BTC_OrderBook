using AutoMapper;
using BTC_OrderBook.Application.Dto.Out.Abstract;
using BTC_OrderBook.Application.Dtos.Out.OrderBook;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BTC_OrderBook.Controller
{
    /// <summary>
    /// Order book controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderBookController : ControllerBase
    {
        private readonly IOrderBookService _orderBookService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Order book controller constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="orderBookService"></param>
        public OrderBookController(IMapper mapper, IOrderBookService orderBookService)
        {
            _orderBookService = orderBookService;
            _mapper = mapper;
        }


        /// <summary>
        /// Get currencies pairs
        /// </summary>
        /// <returns></returns>
        [HttpGet("currecies-pairs")]
        public IActionResult GetCurrenciesPairs()
        {
            var outDto = _mapper.Map<IList<OrderBookCurrencyPairOutDto>>(_orderBookService.CurrenciesPairs);
            return Ok(new BaseOut<IList<OrderBookCurrencyPairOutDto>>(outDto));
        }

        /// <summary>
        /// Get order book async
        /// </summary>
        /// <param name="curreciesPair">Currencies order book pair</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        [HttpGet("{curreciesPair}")]
        public async Task<IActionResult> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken)
        {
            var result = await _orderBookService.GetOrderBookAsync(curreciesPair, cancellationToken);
            var outDto = _mapper.Map<OrderBookOutDto>(result);
            return Ok(new BaseOut<OrderBookOutDto>(outDto));
        }
    }
}
