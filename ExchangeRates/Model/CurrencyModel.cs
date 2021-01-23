using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model
{
    
    public class CurrencyModel
    {
        public string CurrencyCode { get; }          
        public string TextName { get; }
        public string Name { get; }
        public string ExchangeDate { get; }
        public string Rate { get; }
        public CurrencyModel(string currencyCode, string textName, string name, string exchangeDate, string rate)
        {
            CurrencyCode = currencyCode;
            TextName = textName;
            Name = name;
            ExchangeDate = exchangeDate;
            Rate = rate;
        }
    }
}
