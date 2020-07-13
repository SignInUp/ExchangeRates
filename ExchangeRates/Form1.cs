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
        private static void InvalidInputMessage(string errorText) // Метод для вывода сообщения об ошибке ввода
        {
            const string caption = "Invalid input"; // Текст заголовка
            MessageBox.Show(errorText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            // Вывод текста из errorText в окне с заголовком caption, кнопкой ОК и иконкой ошибки 
        }

        private const int CurrencyColumnId = 6; // ИД колонки с валютами
        private const int SaleColumnId = 7; // ИД колонки с ценой продажи валюты
        private const int BuyColumnId = 8; // ИД колонки с ценой покупки валюты
        private readonly Random _rnd = new Random();
        // Поле, отвечающее за рандом. 1 раз проиницилизировано во имя избежания получения одинаковых чисел
        // Проблема описана здесь https://habr.com/ru/post/165459/
        private readonly FinanceView _finance = new FinanceView(); // Поле, отвечающее за обращения к ViewModel
        private Color GetRandomColor() // Метод для получения случайного цвета
        {
            const int minimumChannelValue = 128; // Минимальная величина канала rgb цвета для покраски ячейки
            const int maximumChannelValue = 256; // Максимальная величина канала
                                                 // Сделано такое ограничение чтобы черный текст читался на светлом фоне

            var red = _rnd.Next(minimumChannelValue, maximumChannelValue); // Случайная величина красного канала
            var green = _rnd.Next(minimumChannelValue, maximumChannelValue); // Случайная величина красного канала
            var blue = _rnd.Next(minimumChannelValue, maximumChannelValue); // Случайная величина красного канала
            var color = Color.FromArgb(red, green, blue); // Получение цвета по 3 каналам. Прозрачность = 0

            return color;
        }
        private void ColorizeCells(Color color, int row) // Метод для покраски строки row в цвет color 
        {
            for (var i = 0; i <= BuyColumnId; ++i) // Проход с первой по последнюю ячейку строки
            {
                OrganizationsGrid.Rows[row].Cells[i].Style.BackColor = color; 
            }
        }
        private void ShowOrganizations() // Метод для отображения организаций в сетке
        {
            OrganizationsGrid.Rows.Clear(); // Очистка текущих данных на таблице

            var organizations = _finance.GetOrganizationsData(); // Получение организаций из ViewModel
            var orgCount = organizations.Count; // Количество организаций
            
            var currentRow = 0; // Текущая строка. Переменная нужна для покраски
            var color = GetRandomColor(); // Выбранный цвет для строки. Получается случайно

            for (var i = 0; i < orgCount; ++i) // Проход по всем организациям
            {
                var row = new[] // Массив строк для добавления ее в сетку
                {
                    i.ToString(), // ИД
                    organizations[i].Title, // Название валюты
                    organizations[i].OrgType, // Тип организации
                    organizations[i].City, // Город
                    organizations[i].Address, // Адрес
                    organizations[i].Phone, // Телефон
                    "","",""
                };
                // Если есть хоть 1 валюта 
                if (organizations[i].Currencies.Count > 0) // Добавление данных о валюте в строку row
                {
                    row[CurrencyColumnId] = organizations[i].Currencies[0].Title; // Название валюты
                    row[SaleColumnId] = organizations[i].Currencies[0].Sale; // Цена продажи валюты
                    row[BuyColumnId] = organizations[i].Currencies[0].Buy; // Цена покупки валюты
                    OrganizationsGrid.Rows.Add(row); // Добавление row в сетку
                    ColorizeCells(color, currentRow); // Окраска строки в выбранный цвет
                    ++currentRow; // Смещаем текущую строку на +1
                }
                else // Если нет валют
                {
                    OrganizationsGrid.Rows.Add(row); // Добавление данных банка без валют
                    ColorizeCells(color, currentRow); // Окраска строки
                    ++currentRow; // Смещаем текущую строку на +1
                }
                // Если больше 1 валюты 
                for (var j = 1; j < organizations[i].Currencies.Count; ++j) // Проходим по всем валютам, кроме первой
                {
                    var currencyRow = new[] // Массив строк для добавления в сетку. Имеет только данные о валюте
                    {
                        "", "", "", "", "", "",
                        organizations[i].Currencies[j].Title,
                        organizations[i].Currencies[j].Sale,
                        organizations[i].Currencies[j].Buy
                    };
                    OrganizationsGrid.Rows.Add(currencyRow); // Добавление данных о валюте в сетку
                    ColorizeCells(color, currentRow); // Покраска строки 
                    ++currentRow; // Смещаем текущую строку на +1
                }
                color = GetRandomColor(); // Меняем цвет для следующего банка
            }
        }
        private void ShowOrganizations(string currencyTitle, double from, double to, bool isBuy, bool isSale) // Отображение организаций в сетке по заданным критериям (название валюты, цена продажи-покупки)
        {
            if (to == -1 || from == -1) // Если в каком-то поле ввели -1 - поиск пройдет по любой цене
            {
                from = 0;
                to = double.MaxValue;
            }
            if (from > to) // Если перепутали значения местами
            {
                InvalidInputMessage("Поле 'До' должно иметь большее значение, чем 'От'");
                return;
            }
            if (currencyTitle == "") // Если не выбрали валюту
            {
                InvalidInputMessage("Выберите валюту");
                return;
            }

            OrganizationsGrid.Rows.Clear(); // Очистка сетки от текущих данных

            var organizations = _finance.GetOrganizationsData(); // Получение всех организаций
            var orgCount = organizations.Count; // Количество организаций

            var currentRow = 0; // Текущая строка
            var color = GetRandomColor(); // Цвет

            for (var i = 0; i < orgCount; ++i) // Проход по всем организациям
            {
                var row = new[] // Тоже самое, что и в предыдущем методе
                {
                    i.ToString(),
                    organizations[i].Title,
                    organizations[i].OrgType,
                    organizations[i].City,
                    organizations[i].Address,
                    organizations[i].Phone,
                    "","",""
                };

                foreach (var currency in organizations[i].Currencies) // Нахождение нужной валюты
                {
                    if (currency.Title != currencyTitle) continue; // Если имя не совпадает - пропуск

                    var sale = double.Parse(currency.Sale, CultureInfo.InvariantCulture); // Парсинг из string в double с учетом разделителя '.', а не ',' 
                    var buy = double.Parse(currency.Buy, CultureInfo.InvariantCulture);

                    if (isBuy && isSale && 
                        sale >= @from && sale <= to && 
                        buy >= @from && buy <= to || // Если выбраны и покупка, и продажа, и входные данные входят в рамки 
                        isBuy && !isSale && buy >= @from && buy <= to || // Если выбрана покупка и входные данные входят в рамки
                        isSale && !isBuy && sale >= @from && sale <= to) // Если выбрана продажа и входные данные входят в рамки
                    { // Присваивание к переменной row данных о выбранной валюте
                        row[CurrencyColumnId] = currency.Title; 
                        row[SaleColumnId] = currency.Sale;
                        row[BuyColumnId] = currency.Buy;

                        OrganizationsGrid.Rows.Add(row); // Добавление в сетку организацию

                        ColorizeCells(color, currentRow); // Раскраска строки с организацией
                        ++currentRow; // Смещаем текущую строку на +1
                        color = GetRandomColor(); // Получаем новый случайный цвет

                        break; // Валюту нашли - заканчиваем поиск
                    }
                }

            }

        }
        private void UpdateLogic() // Обновляет данные об организациях
        {
            _finance.UpdateData(); // Само обновление данных
            FillInCurrencyChoice(); // Заново заполняет список валют
            FillInFilesChoice(); // Заново заполняет 
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
        private void ShowOldFile(string name)  
        {
            if (name == "")
            {
                InvalidInputMessage("Выберите файл");
                return;
            }
            _finance.LoadOldData(name);
            ShowOrganizations();
        }
        private void ShowOldFile(string name, string currencyTitle, double from, double to, bool isBuy, bool isSale) 
        {
            if (name == "")
            {
                InvalidInputMessage("Выберите файл");
                return;
            }
            _finance.LoadOldData(name);
            ShowOrganizations(currencyTitle, from, to, isBuy, isSale);
        }
        private void FillInFilesChoice() 
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

        public Form1() // Конструктор. Инициализирует данные 
        {
            InitializeComponent(); // Вызов метода по-умолчанию
            UpdateLogic(); // Инициализация наших данных
        }
        private void UpdateData_Click(object sender, EventArgs e) // Кнопка для обнавления данных об организациях
        {
            UpdateLogic(); // Метод для обновления данных
        }
        private void FindOrganizations_Click(object sender, EventArgs e) // Кнопка для вывода на сетку данных об организациях
        {
            if (SaleChecked.Checked || BuyChecked.Checked) // Если выбрана или продажа, или покупка
            {
                if (!double.TryParse(FromCurrency.Text, out var from) | !double.TryParse(ToCurrency.Text, out var to))
                    // Если не получется спарсить хотя бы один из string в double - вызов окна с ошибкой и завершение вызова метода
                {
                    InvalidInputMessage("Введите в поля числа"); // Окно с ошибкой
                    return;
                }

                ShowOrganizations(CurrencyChoice.Text, from, to, BuyChecked.Checked, SaleChecked.Checked); // Вызов метода для заполнения сетки данными
            }
            else
            {
                ShowOrganizations(); // Если не выбрана продажа или покупка - заполнение сетки всеми имеющимеся данными 
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
