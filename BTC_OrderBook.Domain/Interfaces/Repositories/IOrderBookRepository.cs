using BTC_OrderBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Interfaces.Repositories
{
    public interface IOrderBookRepository : IBaseRepository<OrderBookEntity>
    {
    }
}
