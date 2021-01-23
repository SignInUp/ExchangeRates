using System;
using System.Windows.Forms;
using ExchangeRates.Api;

namespace ExchangeRates
{
    public partial class Form1 : Form
    {
        private readonly FinanceApi _financeApi = new FinanceApi();
        private const string ShowAll = "Все валюты";
        private void UpdateLogic() 
        {
            _financeApi.UpdateData();
            FillInCurrencyGrid();
        }

        private void ShowChosenCurrency()
        {
            var currency = _financeApi.GetCurrency(CurrencyChoice.SelectedItem.ToString());
            ExchangeGrid.Rows.Clear();
            ExchangeGrid.Rows.Add(currency.TextName, currency.Name, currency.CurrencyCode, currency.Rate,
                currency.ExchangeDate);
        }

        private void FilterCurrencyGrid()
        {
            var currencies = _financeApi.GetCurrencies(FilterGridChoice.SelectedItem.ToString());
            ExchangeGrid.Rows.Clear();
            CurrencyChoice.Items.Clear();
            CurrencyChoice.Items.Add(ShowAll);
            CurrencyChoice.SelectedIndex = 0;
            foreach (var currency in currencies)
            {
                CurrencyChoice.Items.Add(currency.Name);
                ExchangeGrid.Rows.Add(currency.TextName, currency.Name, currency.CurrencyCode, currency.Rate, currency.ExchangeDate);
            }
        }
        
        private void FillInCurrencyGrid()
        {
            if (CurrencyChoice.SelectedItem != null && CurrencyChoice.SelectedItem.ToString() != "" && CurrencyChoice.SelectedItem.ToString() != ShowAll)
            { 
                ShowChosenCurrency();
                return;
            }
            FilterCurrencyGrid();
        }
        public Form1() 
        {
            InitializeComponent(); // Вызов метода по-умолчанию
            UpdateLogic(); // Инициализация наших данных
        }

        private void GetExchanges_Click(object sender, EventArgs e)
        {
            UpdateLogic();
        }
    }
}
