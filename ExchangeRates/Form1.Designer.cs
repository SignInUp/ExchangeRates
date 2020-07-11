namespace ExchangeRates
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.UpdateData = new System.Windows.Forms.Button();
            this.FindBanks = new System.Windows.Forms.Button();
            this.OrganizationsGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToCurrency = new System.Windows.Forms.TextBox();
            this.FromCurrency = new System.Windows.Forms.TextBox();
            this.BuyChecked = new System.Windows.Forms.CheckBox();
            this.SaleChecked = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CurrencyChoice = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.FileChoice = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ShowSelectedFile = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateData
            // 
            this.UpdateData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UpdateData.Location = new System.Drawing.Point(929, 8);
            this.UpdateData.Name = "UpdateData";
            this.UpdateData.Size = new System.Drawing.Size(95, 21);
            this.UpdateData.TabIndex = 1;
            this.UpdateData.Text = "Обновить";
            this.UpdateData.UseVisualStyleBackColor = true;
            this.UpdateData.Click += new System.EventHandler(this.UpdateData_Click);
            // 
            // FindBanks
            // 
            this.FindBanks.Location = new System.Drawing.Point(929, 29);
            this.FindBanks.Name = "FindBanks";
            this.FindBanks.Size = new System.Drawing.Size(95, 20);
            this.FindBanks.TabIndex = 2;
            this.FindBanks.Text = "Найти банки";
            this.FindBanks.UseVisualStyleBackColor = true;
            this.FindBanks.Click += new System.EventHandler(this.FindOrganizations_Click);
            // 
            // OrganizationsGrid
            // 
            this.OrganizationsGrid.AllowUserToAddRows = false;
            this.OrganizationsGrid.AllowUserToDeleteRows = false;
            this.OrganizationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizationsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Organization,
            this.OrgType,
            this.City,
            this.Address,
            this.Phone,
            this.Currency,
            this.Sale,
            this.Buy});
            this.OrganizationsGrid.Location = new System.Drawing.Point(14, 57);
            this.OrganizationsGrid.Name = "OrganizationsGrid";
            this.OrganizationsGrid.ReadOnly = true;
            this.OrganizationsGrid.Size = new System.Drawing.Size(1010, 612);
            this.OrganizationsGrid.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Organization
            // 
            this.Organization.HeaderText = "Организация";
            this.Organization.Name = "Organization";
            this.Organization.ReadOnly = true;
            this.Organization.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Organization.Width = 130;
            // 
            // OrgType
            // 
            this.OrgType.HeaderText = "Тип организации";
            this.OrgType.Name = "OrgType";
            this.OrgType.ReadOnly = true;
            this.OrgType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrgType.Width = 120;
            // 
            // City
            // 
            this.City.HeaderText = "Город";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Телефон";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Валюта";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            this.Currency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sale
            // 
            this.Sale.HeaderText = "Продажа";
            this.Sale.Name = "Sale";
            this.Sale.ReadOnly = true;
            this.Sale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Buy
            // 
            this.Buy.HeaderText = "Покупка";
            this.Buy.Name = "Buy";
            this.Buy.ReadOnly = true;
            this.Buy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToCurrency
            // 
            this.ToCurrency.Location = new System.Drawing.Point(701, 29);
            this.ToCurrency.Name = "ToCurrency";
            this.ToCurrency.Size = new System.Drawing.Size(147, 20);
            this.ToCurrency.TabIndex = 4;
            this.ToCurrency.Text = "До";
            // 
            // FromCurrency
            // 
            this.FromCurrency.Location = new System.Drawing.Point(548, 29);
            this.FromCurrency.Name = "FromCurrency";
            this.FromCurrency.Size = new System.Drawing.Size(147, 20);
            this.FromCurrency.TabIndex = 5;
            this.FromCurrency.Text = "От (-1 для любых значений)";
            // 
            // BuyChecked
            // 
            this.BuyChecked.AutoSize = true;
            this.BuyChecked.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BuyChecked.Location = new System.Drawing.Point(751, 7);
            this.BuyChecked.Name = "BuyChecked";
            this.BuyChecked.Size = new System.Drawing.Size(69, 17);
            this.BuyChecked.TabIndex = 6;
            this.BuyChecked.Text = "Покупка";
            this.BuyChecked.UseVisualStyleBackColor = true;
            // 
            // SaleChecked
            // 
            this.SaleChecked.AutoSize = true;
            this.SaleChecked.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SaleChecked.Location = new System.Drawing.Point(673, 7);
            this.SaleChecked.Name = "SaleChecked";
            this.SaleChecked.Size = new System.Drawing.Size(72, 17);
            this.SaleChecked.TabIndex = 7;
            this.SaleChecked.Text = "Продажа";
            this.SaleChecked.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(548, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Жлаемый курс (в грн)";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrencyChoice
            // 
            this.CurrencyChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrencyChoice.FormattingEnabled = true;
            this.CurrencyChoice.Location = new System.Drawing.Point(351, 28);
            this.CurrencyChoice.Name = "CurrencyChoice";
            this.CurrencyChoice.Size = new System.Drawing.Size(191, 21);
            this.CurrencyChoice.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(351, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(191, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Выбор валюты";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileChoice
            // 
            this.FileChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileChoice.FormattingEnabled = true;
            this.FileChoice.Location = new System.Drawing.Point(115, 30);
            this.FileChoice.Name = "FileChoice";
            this.FileChoice.Size = new System.Drawing.Size(152, 21);
            this.FileChoice.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(115, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(152, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "Выберите файл";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ShowSelectedFile
            // 
            this.ShowSelectedFile.Location = new System.Drawing.Point(14, 30);
            this.ShowSelectedFile.Name = "ShowSelectedFile";
            this.ShowSelectedFile.Size = new System.Drawing.Size(95, 21);
            this.ShowSelectedFile.TabIndex = 13;
            this.ShowSelectedFile.Text = "Показать";
            this.ShowSelectedFile.UseVisualStyleBackColor = true;
            this.ShowSelectedFile.Click += new System.EventHandler(this.ShowSelectedFile_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(854, 8);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(70, 21);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1036, 681);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ShowSelectedFile);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.FileChoice);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.CurrencyChoice);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SaleChecked);
            this.Controls.Add(this.BuyChecked);
            this.Controls.Add(this.FromCurrency);
            this.Controls.Add(this.ToCurrency);
            this.Controls.Add(this.OrganizationsGrid);
            this.Controls.Add(this.FindBanks);
            this.Controls.Add(this.UpdateData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Данные обмен валют";
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button UpdateData;
        private System.Windows.Forms.Button FindBanks;
        private System.Windows.Forms.DataGridView OrganizationsGrid;
        private System.Windows.Forms.TextBox ToCurrency;
        private System.Windows.Forms.TextBox FromCurrency;
        private System.Windows.Forms.CheckBox BuyChecked;
        private System.Windows.Forms.CheckBox SaleChecked;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CurrencyChoice;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgType;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy;
        private System.Windows.Forms.ComboBox FileChoice;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button ShowSelectedFile;
        private System.Windows.Forms.Button SaveButton;
    }
}

