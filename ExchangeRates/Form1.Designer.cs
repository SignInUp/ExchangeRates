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
            this.ИД = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateData
            // 
            this.UpdateData.Location = new System.Drawing.Point(1097, 12);
            this.UpdateData.Name = "UpdateData";
            this.UpdateData.Size = new System.Drawing.Size(75, 23);
            this.UpdateData.TabIndex = 1;
            this.UpdateData.Text = "Обновить";
            this.UpdateData.UseVisualStyleBackColor = true;
            this.UpdateData.Click += new System.EventHandler(this.UpdateData_Click);
            // 
            // FindBanks
            // 
            this.FindBanks.Location = new System.Drawing.Point(999, 12);
            this.FindBanks.Name = "FindBanks";
            this.FindBanks.Size = new System.Drawing.Size(92, 23);
            this.FindBanks.TabIndex = 2;
            this.FindBanks.Text = "Найти банки";
            this.FindBanks.UseVisualStyleBackColor = true;
            this.FindBanks.Click += new System.EventHandler(this.FindBanks_Click);
            // 
            // OrganizationsGrid
            // 
            this.OrganizationsGrid.AllowUserToAddRows = false;
            this.OrganizationsGrid.AllowUserToDeleteRows = false;
            this.OrganizationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizationsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ИД,
            this.Organization,
            this.OrgType,
            this.City,
            this.Address,
            this.Phone,
            this.Currency,
            this.Sale,
            this.Buy});
            this.OrganizationsGrid.Location = new System.Drawing.Point(12, 41);
            this.OrganizationsGrid.Name = "OrganizationsGrid";
            this.OrganizationsGrid.ReadOnly = true;
            this.OrganizationsGrid.Size = new System.Drawing.Size(1160, 628);
            this.OrganizationsGrid.TabIndex = 3;
            this.OrganizationsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrganizationsGrid_CellContentClick);
            // 
            // ИД
            // 
            this.ИД.HeaderText = "ID";
            this.ИД.Name = "ИД";
            this.ИД.ReadOnly = true;
            // 
            // Organization
            // 
            this.Organization.HeaderText = "Организация";
            this.Organization.Name = "Organization";
            this.Organization.ReadOnly = true;
            this.Organization.Width = 130;
            // 
            // OrgType
            // 
            this.OrgType.HeaderText = "Тип организации";
            this.OrgType.Name = "OrgType";
            this.OrgType.ReadOnly = true;
            this.OrgType.Width = 120;
            // 
            // City
            // 
            this.City.HeaderText = "Город";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Телефон";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Валюта";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            // 
            // Sale
            // 
            this.Sale.HeaderText = "Продажа";
            this.Sale.Name = "Sale";
            this.Sale.ReadOnly = true;
            // 
            // Buy
            // 
            this.Buy.HeaderText = "Покупка";
            this.Buy.Name = "Buy";
            this.Buy.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.OrganizationsGrid);
            this.Controls.Add(this.FindBanks);
            this.Controls.Add(this.UpdateData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button UpdateData;
        private System.Windows.Forms.Button FindBanks;
        private System.Windows.Forms.DataGridView OrganizationsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ИД;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgType;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy;
    }
}

