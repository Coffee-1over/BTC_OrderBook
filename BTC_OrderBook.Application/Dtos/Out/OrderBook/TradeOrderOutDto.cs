using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Application.Dtos.Out.OrderBook
{
    public class TradeOrderOutDto
    {
        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
