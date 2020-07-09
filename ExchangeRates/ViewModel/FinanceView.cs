using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRates.Model;

namespace ExchangeRates.ViewModel
{
    public static class FinanceView
    {
        public static void UpdateData()
        {
            FinanceApi.UpdateData();
        }
        public static List<OrganizationViewModel> GetOrganizationsData()
        {
            var organizationsRawData = FinanceApi.GetOrganizations();
            var cities = FinanceApi.GetCities();
            //var regions = FinanceApi.GetRegions();
            var currencies = FinanceApi.GetCurrencies();
            var orgTypes = FinanceApi.GetOrgTypes();

            var organizationsViewData = new List<OrganizationViewModel>();

            foreach (var organization in organizationsRawData)
            {
                var title = organization.Title;
                var phone = organization.Phone;
                var address = organization.Address;
                var orgType = FinanceApi.GetValidValue(orgTypes, organization.OrgType);
                var city = FinanceApi.GetValidValue(cities, organization.City);

                var viewCurrencies = new List<CurrencyViewModel>();

                foreach (var currency in organization.Currencies)
                {
                    var name = FinanceApi.GetValidValue(currencies, currency.Id);
                    var buy = currency.Buy;
                    var sale = currency.Sale;

                    viewCurrencies.Add(new CurrencyViewModel(name, buy, sale));
                }
                organizationsViewData.Add(new OrganizationViewModel(title, city, address, orgType, phone, viewCurrencies));
            }

            return organizationsViewData;
        }

    }
}
