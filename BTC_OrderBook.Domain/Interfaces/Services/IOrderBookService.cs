using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Enums;
using BTC_OrderBook.Domain.Models.Clients.OrderBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Services.Abstract
{
    public interface IOrderBookService
    {
        Task<OrderBookClientModel> GetOrderBookAsync(OrderBookCurreciesPair curreciesPair, CancellationToken cancellationToken);
    }
}
