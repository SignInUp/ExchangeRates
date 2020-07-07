using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model
{
    public struct OrganizationModel
    {
        public string Id { get; set; }
        public string OldId { get; set; }
        public string OrgType { get; set; }
        public string Title { get; set; }
        public string Branch { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<CurrencyModel> Currencies { get; set; }
        public OrganizationModel(string id, string oldId, string orgType, string title, string branch, 
            string region, string city, string phone, string address, List<CurrencyModel> currencies)
        {
            Id = id;
            OldId = oldId;
            OrgType = orgType;
            Title = title;
            Branch = branch;
            Region = region;
            City = city;
            Phone = phone;
            Address = address;
            Currencies = currencies;
        }

    }
}
