using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Models.Clients.OrderBook
{
    public class OrderBookClientModel
    {
        public long Timestamp { get; set; }
        public IList<IList<decimal>> Bids { get; set; }
        public IList<IList<decimal>> Asks { get; set; }
    }
}
