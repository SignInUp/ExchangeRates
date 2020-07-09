using System.Collections.Generic;
using ExchangeRates.Model;

namespace ExchangeRates.ViewModel
{
    public struct OrganizationViewModel
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string OrgType { get; set; }
        public string Phone { get; set; }
        public List<CurrencyViewModel> Currencies { get; set; }
        public OrganizationViewModel(string title, string city, string address,
            string orgType, string phone, List<CurrencyViewModel> currencies)
        {
            Title = title;
            City = city;
            Address = address;
            OrgType = orgType;
            Phone = phone;
            Currencies = currencies;
        }
    }
}
