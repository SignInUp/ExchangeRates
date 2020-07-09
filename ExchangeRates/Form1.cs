using System;
using System.Windows.Forms;
using ExchangeRates.ViewModel;

namespace ExchangeRates
{
    public partial class Form1 : Form
    {
        private const int CurrencyColumnId = 6;
        private const int SaleColumnId = 7;
        private const int BuyColumnId = 8;
        private void ShowOrganizations()
        {
            var organizations = FinanceView.GetOrganizationsData();
            var orgCount = organizations.Count;
            for (var i = 0; i < orgCount; ++i)
            {
                // Info without currencies
                var row = new[]
                {
                    i.ToString(),
                    organizations[i].Title,
                    organizations[i].OrgType,
                    organizations[i].City,
                    organizations[i].Address,
                    organizations[i].Phone,
                    "","",""
                };
                //If we have at least 1 currency
                if (organizations[i].Currencies.Count > 0)
                {
                    row[CurrencyColumnId] = organizations[i].Currencies[0].Title;
                    row[SaleColumnId] = organizations[i].Currencies[0].Sale;
                    row[BuyColumnId] = organizations[i].Currencies[0].Buy;
                    OrganizationsGrid.Rows.Add(row);
                }
                else
                {
                    OrganizationsGrid.Rows.Add(row);
                }
                //If we have more then 1 currency
                for (var j = 1; j < organizations[i].Currencies.Count; ++j)
                {
                    var currencyRow = new[]
                    {
                        "", "", "", "", "", "",
                        organizations[i].Currencies[j].Title,
                        organizations[i].Currencies[j].Sale,
                        organizations[i].Currencies[j].Buy
                    };
                    OrganizationsGrid.Rows.Add(currencyRow);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            FinanceView.UpdateData();
        }
        private void UpdateData_Click(object sender, EventArgs e)
        {
            FinanceView.UpdateData();
            ShowOrganizations();
        }
        private void FindBanks_Click(object sender, EventArgs e)
        {
            ShowOrganizations();
        }
        private void OrganizationsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
