using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model
{
    public struct CurrencyModel
    {
        public string Id { get; set; }
        public string Buy { get; set; } // br
        public string Sale { get; set; } // ar

        public CurrencyModel(string id, string buy, string sale)
        {
            Id = id;
            Buy = buy;
            Sale = sale;
        }
    }
}
