
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace ExchangeRates.Model
{
    public static class Finance
    {
        private const string Url = "http://resources.finance.ua/ru/public/currency-cash.xml";
        public static XmlDocument RawData { get; } = new XmlDocument();

        // Nodes names
        private const string Organizations = "organizations";
        private const string OrgTypes = "org_types";
        private const string Currencies = "currencies";
        private const string Regions = "regions";
        private const string Cities = "cities";
        private const string Source = "source";
        private const string Title = "title";
        private const string Branch = "branch";
        private const string Region = "region";
        private const string City = "city";
        private const string Phone = "phone";
        private const string Address = "address";

        public static void UpdateData()
        {
            RawData.Load(Url);
        }
        public static List<OrganizationModel> GetOrganizations()
        {
            var resultOrganizations = new List<OrganizationModel>();
            var xmlOrganizations = RawData.SelectNodes("/" + Source + "/" + Organizations)[0].ChildNodes;

            // cycle in organizations node
            foreach (XmlNode organization in xmlOrganizations)
            {
                var organizationId = organization.Attributes[0].Value;
                var organizationOldId = organization.Attributes[1].Value;
                var orgType = organization.Attributes[2].Value;

                var title = "";
                var branch = "";
                var region = "";
                var city = "";
                var phone = "";
                var address = "";
                var currencies = new List<CurrencyModel>();

                // cycle in organization in organizations (node)
                foreach (XmlNode orgData in organization.ChildNodes)
                {
                    if (orgData.Attributes.Count == 0)
                        continue;

                    switch (orgData.Name)
                    {
                        case Title:
                            title = orgData.Attributes[0].Value;
                            break;
                        case Branch:
                            branch = orgData.Attributes[0].Value;
                            break;
                        case Region:
                            region = orgData.Attributes[0].Value; ;
                            break;
                        case City:
                            city = orgData.Attributes[0].Value;
                            break;
                        case Phone:
                            phone = orgData.Attributes[0].Value;
                            break;
                        case Address:
                            address = orgData.Attributes[0].Value;
                            break;
                        case Currencies:
                            // linq in currencies in organization in organizations (node)
                            currencies.AddRange(from XmlNode currency
                                                in orgData.ChildNodes
                                                select new CurrencyModel(
                                                    currency.Attributes[0].Value,
                                                    currency.Attributes[1].Value,
                                                    currency.Attributes[2].Value
                                                ));
                            break;
                    }
                }
                resultOrganizations.Add(new OrganizationModel(organizationId, organizationOldId,
                                    orgType, title, branch, region, city, phone, address, currencies));
            }
            return resultOrganizations;
        }
        public static List<ExtraDataModel> GetCurrencies()
        {
            var xmlCurrencies = RawData.SelectNodes("/" + Source + "/" + Currencies)[0].ChildNodes;

            return (from XmlNode currency
                    in xmlCurrencies
                    let id = currency.Attributes[0].Value
                    let title = currency.Attributes[1].Value
                    select new ExtraDataModel(id, title))
                .ToList();
        }
        public static List<ExtraDataModel> GetCities()
        {
            var xmlCities = RawData.SelectNodes("/" + Source + "/" + Cities)[0].ChildNodes;

            return (from XmlNode city
                    in xmlCities
                    let id = city.Attributes[0].Value
                    let title = city.Attributes[1].Value
                    select new ExtraDataModel(id, title))
                .ToList();
        }
        public static List<ExtraDataModel> GetRegions()
        {
            var xmlRegions = RawData.SelectNodes("/" + Source + "/" + Regions)[0].ChildNodes;

            return (from XmlNode region
                    in xmlRegions
                    let id = region.Attributes[0].Value
                    let title = region.Attributes[1].Value
                    select new ExtraDataModel(id, title))
                .ToList();
        }
        public static List<ExtraDataModel> GetOrgTypes()
        {
            var xmlOrgTypes = RawData.SelectNodes("/" + Source + "/" + OrgTypes)[0].ChildNodes;

            return (from XmlNode orgType
                    in xmlOrgTypes
                    let id = orgType.Attributes[0].Value
                    let title = orgType.Attributes[1].Value
                    select new ExtraDataModel(id, title))
                .ToList();
        }
    }
}