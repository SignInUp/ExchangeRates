using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExchangeRates.Model;
using ExchangeRates.SaveLoad;

namespace ExchangeRates.ViewModel
{
    public class FinanceView
    {
        private readonly FinanceApi _finance;
        public FinanceView()
        {
            _finance = new FinanceApi();
        }
        public void UpdateData()
        {
            _finance.UpdateData();
        }
        public List<OrganizationViewModel> GetOrganizationsData()
        {
            var organizationsRawData = _finance.GetOrganizations();
            var cities = _finance.GetCities();
            var currencies = _finance.GetCurrencies();
            var orgTypes = _finance.GetOrgTypes();

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
        public List<string> GetCurrenciesTitle()
        {
            var currencies = _finance.GetCurrencies();
            var titlesList = new List<string>();
            foreach (var currency in currencies)
            {
                titlesList.Add(currency.Title);
            }

            return titlesList;
        }
        public void LoadOldData(string name) // Made by Eugene 
        {
            var xml = SaveLoadXml.Load(name);
            _finance.UpdateData(xml);
        }
        public string[] GetLoadedFilesName() // Made by Eugene 
        {
            var files = Directory.GetFiles(SaveLoadXml.Path).ToList();
            for (var i = 0; i < files.Count; ++i)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
            return files.ToArray();
        }
        public void SaveData()
        {
            SaveLoadXml.Save(_finance.RawData);
        }
    }
}
