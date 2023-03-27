using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;

namespace BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook
{
    public class BitstampOrderBookConfig
    {
        public string Link { get; set; }
        public BitstampOrderBookAdditionalInfoConfig AdditionalInfo { get; set; }
    }
}
