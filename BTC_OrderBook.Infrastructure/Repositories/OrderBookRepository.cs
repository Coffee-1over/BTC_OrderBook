using AutoMapper;
using BTC_OrderBook.Domain.Entities;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using BTC_OrderBook.Infrastructure.Contexts;
using BTC_OrderBook.Infrastructure.Repository.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Infrastructure.Repositories
{
    public class OrderBookRepository : BaseRepository<OrderBookEntity>, IOrderBookRepository
    {
        public OrderBookRepository(ApplicationContext context, ILogger<OrderBookRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
