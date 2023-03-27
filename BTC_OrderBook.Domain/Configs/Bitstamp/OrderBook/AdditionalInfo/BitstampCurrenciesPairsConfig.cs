using BTC_OrderBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo
{
    public class BitstampCurrenciesPairsConfig
    {
        public string View { get; set; }
        public OrderBookCurreciesPair Value { get; set; }
    }
}
