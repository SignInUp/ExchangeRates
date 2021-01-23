using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using ExchangeRates.Model;

namespace ExchangeRates.Api
{
    public static class ApiTypes
    {
        public const string ExchangeType = "exchange";
        public static class Exchange
        {
            public const string CurrencyType = "currency";
            public static class Currency
            {
                public const string CurrencyCode = "r030";          
                public const string TextName = "txt";
                public const string Name = "cc";
                public const string ExchangeDate = "exchangedate";
                public const string Rate = "rate";
            }    
        }
    }
    
    public static class CurrencyTypes 
    {
        public const string CurrencyCodeA = "Код (по возрастанию)";          
        public const string TextNameA = "Название валюты (по возрастанию)";
        public const string NameA = "Валюта (по возрастанию)";
        public const string RateA = "Стоимость (по возрастанию)";        
        
        public const string CurrencyCodeD = "Код (по убыванию)";          
        public const string TextNameD = "Название валюты (по убыванию)";
        public const string NameD = "Валюта (по убыванию)";
        public const string RateD = "Стоимость (по убыванию)";

        public static object[] GetTypes()
        {
            return new object[]
            {
                CurrencyCodeA,     
                CurrencyCodeD,          

                TextNameA,
                TextNameD,

                NameA,
                NameD,

                RateA,
                RateD
            };
        }
    }
    
    public class FinanceApi
    {
        private const string Url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange";
        public XmlDocument RawData { get; } = new XmlDocument();

        public FinanceApi()
        {
            UpdateData();
        }
        public void UpdateData()
        {
            RawData.Load(Url);
        }

        private static IEnumerable<CurrencyModel> FilterCurrencies(IEnumerable<CurrencyModel> currencies, string filter)
        {
            switch (filter)
            {
                case CurrencyTypes.NameA:
                    return (from c in currencies orderby c.Name select c).ToList();
                case CurrencyTypes.RateA:
                    return (from c in currencies orderby double.Parse(c.Rate, CultureInfo.InvariantCulture) select c).ToList();
                case CurrencyTypes.CurrencyCodeA:
                    return (from c in currencies orderby c.CurrencyCode select c).ToList();
                case CurrencyTypes.TextNameA:
                    return (from c in currencies orderby c.TextName select c).ToList();                
                
                case CurrencyTypes.NameD:
                    return (from c in currencies orderby c.Name descending select c).ToList();
                case CurrencyTypes.RateD:
                    return (from c in currencies orderby double.Parse(c.Rate, CultureInfo.InvariantCulture) descending select c).ToList();
                case CurrencyTypes.CurrencyCodeD:
                    return (from c in currencies orderby c.CurrencyCode descending select c).ToList();
                case CurrencyTypes.TextNameD:
                    return (from c in currencies orderby c.TextName descending select c).ToList();
            }
            return currencies;
        }
        public IEnumerable<CurrencyModel> GetCurrencies(string filterBy = CurrencyTypes.NameA)
        {
            var xmlCurrencies = RawData.SelectNodes($"/{ApiTypes.ExchangeType}/{ApiTypes.Exchange.CurrencyType}");
            if (xmlCurrencies == null)
            {
                return new List<CurrencyModel>();
            }

            var currenciesList = (from XmlNode currency in xmlCurrencies
                let curCode = currency.SelectSingleNode(ApiTypes.Exchange.Currency.CurrencyCode)?.InnerText
                let textName = currency.SelectSingleNode(ApiTypes.Exchange.Currency.TextName)?.InnerText 
                let name = currency.SelectSingleNode(ApiTypes.Exchange.Currency.Name)?.InnerText 
                let exchangeDate = currency.SelectSingleNode(ApiTypes.Exchange.Currency.ExchangeDate)?.InnerText 
                let rate = currency.SelectSingleNode(ApiTypes.Exchange.Currency.Rate)?.InnerText 
                select new CurrencyModel(curCode, textName, name, exchangeDate, rate))
                .ToList();
            return FilterCurrencies(currenciesList, filterBy);
        }
        public CurrencyModel GetCurrency(string currencyName)
        {
            var xmlCurrencies = RawData.SelectNodes($"/{ApiTypes.ExchangeType}/{ApiTypes.Exchange.CurrencyType}");
            return (from XmlNode currency in xmlCurrencies 
                let name = currency.SelectSingleNode(ApiTypes.Exchange.Currency.Name)?.InnerText 
                where name == currencyName 
                let curCode = currency.SelectSingleNode(ApiTypes.Exchange.Currency.CurrencyCode)?.InnerText 
                let textName = currency.SelectSingleNode(ApiTypes.Exchange.Currency.TextName)?.InnerText 
                let exchangeDate = currency.SelectSingleNode(ApiTypes.Exchange.Currency.ExchangeDate)?.InnerText 
                let rate = currency.SelectSingleNode(ApiTypes.Exchange.Currency.Rate)?.InnerText 
                select new CurrencyModel(curCode, textName, name, exchangeDate, rate))
                .FirstOrDefault();
        }
    }
}