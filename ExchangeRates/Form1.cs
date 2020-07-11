using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ExchangeRates.ViewModel;

namespace ExchangeRates
{
    public partial class Form1 : Form
    {
        private static void InvalidInputMessage(string errorText)
        {
            const string caption = "Invalid input";
            MessageBox.Show(errorText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private const int CurrencyColumnId = 6;
        private const int SaleColumnId = 7;
        private const int BuyColumnId = 8;
        private readonly Random _rnd = new Random();
        private readonly FinanceView _finance = new FinanceView();
        private Color GetRandomColor()
        {
            const int minimumChannelValue = 128;
            const int maximumChannelValue = 256;

            var red = _rnd.Next(minimumChannelValue, maximumChannelValue);
            var green = _rnd.Next(minimumChannelValue, maximumChannelValue);
            var blue = _rnd.Next(minimumChannelValue, maximumChannelValue);
            var color = Color.FromArgb(red, green, blue);

            return color;
        }
        private void ColorizeCells(Color color, int row)
        {
            for (var i = 0; i <= BuyColumnId; ++i)
            {
                OrganizationsGrid.Rows[row].Cells[i].Style.BackColor = color;
            }
        }
        private void ShowOrganizations()
        {
            OrganizationsGrid.Rows.Clear();

            var organizations = _finance.GetOrganizationsData();
            var orgCount = organizations.Count;
            
            var currentRow = 0;
            var color = GetRandomColor();

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
                    ColorizeCells(color, currentRow);
                    ++currentRow;
                }
                else
                {
                    OrganizationsGrid.Rows.Add(row);
                    ColorizeCells(color, currentRow);
                    ++currentRow;
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
                    ColorizeCells(color, currentRow);
                    ++currentRow;
                }
                color = GetRandomColor();
            }
        }
        private void ShowOrganizations(string currencyTitle, double from, double to, bool isBuy, bool isSale)
        {
            if (to == -1 || from == -1)
            {
                from = 0;
                to = double.MaxValue;
            }
            if (from > to)
            {
                InvalidInputMessage("Поле 'До' должно иметь большее значение, чем 'От'");
                return;
            }
            if (currencyTitle == "")
            {
                InvalidInputMessage("Выберите валюту");
                return;
            }

            OrganizationsGrid.Rows.Clear();

            var organizations = _finance.GetOrganizationsData();
            var orgCount = organizations.Count;

            var currentRow = 0;
            var color = GetRandomColor();

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

                foreach (var currency in organizations[i].Currencies)
                {
                    if (currency.Title != currencyTitle) continue;

                    var sale = double.Parse(currency.Sale, CultureInfo.InvariantCulture);
                    var buy = double.Parse(currency.Buy, CultureInfo.InvariantCulture);

                    if (isBuy && isSale && 
                        sale >= @from && sale <= to && 
                        buy >= @from && buy <= to || // if both checked 
                        isBuy && !isSale && buy >= @from && buy <= to || // if buy checked only
                        isSale && !isBuy && sale >= @from && sale <= to) // if sale checked only
                    {
                        row[CurrencyColumnId] = currency.Title;
                        row[SaleColumnId] = currency.Sale;
                        row[BuyColumnId] = currency.Buy;

                        OrganizationsGrid.Rows.Add(row);

                        ColorizeCells(color, currentRow);
                        ++currentRow;
                        color = GetRandomColor();

                        break;
                    }
                }

            }

        }
        private void FillInCurrencyChoice()
        {
            CurrencyChoice.Items.Clear();
            var currencies = _finance.GetCurrenciesTitle();
            foreach (var title in currencies)
            {
                CurrencyChoice.Items.Add(title);
            }
        }
        private void UpdateLogic()
        {
            _finance.UpdateData();
            FillInCurrencyChoice();
            FillInFilesChoice();
        }
        private void ShowOldFile(string name) // Made by Eugene 
        {
            if (name == "")
            {
                InvalidInputMessage("Выберите файл");
                return;
            }
            _finance.LoadOldData(name);
            ShowOrganizations();
        }
        private void ShowOldFile(string name, string currencyTitle, double from, double to, bool isBuy, bool isSale) // Made by Eugene
        {
            if (name == "")
            {
                InvalidInputMessage("Выберите файл");
                return;
            }
            _finance.LoadOldData(name);
            ShowOrganizations(currencyTitle, from, to, isBuy, isSale);
        }
        private void FillInFilesChoice() // Made by Eugene 
        {
            FileChoice.Items.Clear();
            var filesName = _finance.GetLoadedFilesName();
            FileChoice.Items.AddRange(filesName);
        }
        private void SaveFile()
        {
            _finance.SaveData();
            FillInFilesChoice();
        }

        public Form1()
        {
            InitializeComponent();
            UpdateLogic();
        }
        private void UpdateData_Click(object sender, EventArgs e)
        {
            UpdateLogic();
        }
        private void FindOrganizations_Click(object sender, EventArgs e)
        {
            if (SaleChecked.Checked || BuyChecked.Checked)
            {
                if (!double.TryParse(FromCurrency.Text, out var from) | !double.TryParse(ToCurrency.Text, out var to))
                {
                    InvalidInputMessage("Введите в поля числа");
                    return;
                }

                ShowOrganizations(CurrencyChoice.Text, from, to, BuyChecked.Checked, SaleChecked.Checked);
            }
            else
            {
                ShowOrganizations();
            }
        }
        private void ShowSelectedFile_Click(object sender, EventArgs e)
        {
            if (SaleChecked.Checked || BuyChecked.Checked)
            {
                if (!double.TryParse(FromCurrency.Text, out var from) | !double.TryParse(ToCurrency.Text, out var to))
                {
                    InvalidInputMessage("Введите в поля числа");
                    return;
                }

                ShowOldFile(FileChoice.Text, CurrencyChoice.Text, from, to, BuyChecked.Checked, SaleChecked.Checked);
            }
            else
            {
                ShowOldFile(FileChoice.Text);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
    }
}
