using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ViewModel
{
    public struct CurrencyViewModel
    {
        public string Title { get; set; }
        public string Buy { get; set; } // br
        public string Sale { get; set; } // ar

        public CurrencyViewModel(string title, string buy, string sale)
        {
            Title = title;
            Buy = buy;
            Sale = sale;
        }
    }
}
