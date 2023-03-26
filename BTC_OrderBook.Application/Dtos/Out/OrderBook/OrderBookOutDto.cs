using BTC_OrderBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Application.Dtos.Out.OrderBook
{
    public class OrderBookOutDto
    {
        public long Timestamp { get; set; }
        public IList<TradeOrderOutDto> Asks { get; set; }
        public IList<TradeOrderOutDto> Bids { get; set; }
    }
}
