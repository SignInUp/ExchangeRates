using System.Windows.Forms;
using ExchangeRates.Api;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.GetExchanges = new System.Windows.Forms.Button();
            this.ExchangeGrid = new System.Windows.Forms.DataGridView();
            this.TextName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyChoice = new System.Windows.Forms.ComboBox();
            this.FilterGridChoice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize) (this.ExchangeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // GetExchanges
            // 
            this.GetExchanges.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.GetExchanges.Location = new System.Drawing.Point(11, 12);
            this.GetExchanges.Name = "GetExchanges";
            this.GetExchanges.Size = new System.Drawing.Size(190, 38);
            this.GetExchanges.TabIndex = 4;
            this.GetExchanges.Text = "Найти ";
            this.GetExchanges.UseVisualStyleBackColor = true;
            this.GetExchanges.Click += new System.EventHandler(this.GetExchanges_Click);
            // 
            // ExchangeGrid
            // 
            this.ExchangeGrid.AllowUserToAddRows = false;
            this.ExchangeGrid.AllowUserToDeleteRows = false;
            this.ExchangeGrid.AllowUserToOrderColumns = true;
            this.ExchangeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExchangeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.TextName, this.CurrencyName, this.CurrencyCode, this.Rate, this.ExchangeRate});
            this.ExchangeGrid.Location = new System.Drawing.Point(207, 12);
            this.ExchangeGrid.Name = "ExchangeGrid";
            this.ExchangeGrid.ReadOnly = true;
            this.ExchangeGrid.Size = new System.Drawing.Size(817, 657);
            this.ExchangeGrid.TabIndex = 3;
            // 
            // TextName
            // 
            this.TextName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TextName.DataPropertyName = "CurrencyTextName";
            this.TextName.HeaderText = "Название валюты";
            this.TextName.Name = "TextName";
            this.TextName.ReadOnly = true;
            this.TextName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CurrencyName
            // 
            this.CurrencyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CurrencyName.DataPropertyName = "CurrencyName";
            this.CurrencyName.HeaderText = "Валюта";
            this.CurrencyName.Name = "CurrencyName";
            this.CurrencyName.ReadOnly = true;
            this.CurrencyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CurrencyCode
            // 
            this.CurrencyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CurrencyCode.DataPropertyName = "CurrencyCode";
            this.CurrencyCode.HeaderText = "Код";
            this.CurrencyCode.Name = "CurrencyCode";
            this.CurrencyCode.ReadOnly = true;
            this.CurrencyCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Rate
            // 
            this.Rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rate.DataPropertyName = "Rate";
            this.Rate.HeaderText = "Стоимость";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExchangeRate.DataPropertyName = "ExchangeDate";
            this.ExchangeRate.HeaderText = "Дата установки цены";
            this.ExchangeRate.Name = "ExchangeRate";
            this.ExchangeRate.ReadOnly = true;
            this.ExchangeRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CurrencyChoice
            // 
            this.CurrencyChoice.Location = new System.Drawing.Point(12, 56);
            this.CurrencyChoice.Name = "CurrencyChoice";
            this.CurrencyChoice.Size = new System.Drawing.Size(189, 21);
            this.CurrencyChoice.TabIndex = 1;
            // 
            // FilterGridChoice
            // 
            this.FilterGridChoice.Items.AddRange(CurrencyTypes.GetTypes());
            this.FilterGridChoice.Location = new System.Drawing.Point(11, 83);
            this.FilterGridChoice.Name = "FilterGridChoice";
            this.FilterGridChoice.Size = new System.Drawing.Size(189, 21);
            this.FilterGridChoice.SelectedIndex = 0;
            this.FilterGridChoice.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.ClientSize = new System.Drawing.Size(1036, 681);
            this.Controls.Add(this.FilterGridChoice);
            this.Controls.Add(this.CurrencyChoice);
            this.Controls.Add(this.ExchangeGrid);
            this.Controls.Add(this.GetExchanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.ExchangeGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox FilterGridChoice;

        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextName;

        private System.Windows.Forms.ComboBox CurrencyChoice;

        private System.Windows.Forms.DataGridView ExchangeGrid;
        private System.Windows.Forms.Button GetExchanges;

        #endregion
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
    }
}

