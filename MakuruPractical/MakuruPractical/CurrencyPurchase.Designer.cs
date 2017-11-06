namespace MakuruPractical
{
    partial class CurrencyPurchase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bsCurrency = new System.Windows.Forms.BindingSource(this.components);
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.nudForeignValue = new System.Windows.Forms.NumericUpDown();
            this.lblLocalOwed = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblCurrencyToBuy = new System.Windows.Forms.Label();
            this.lblLocalValueOwed = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeignValue)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DataSource = this.bsCurrency;
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(171, 16);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(120, 21);
            this.cmbCurrency.TabIndex = 0;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // nudForeignValue
            // 
            this.nudForeignValue.DecimalPlaces = 2;
            this.nudForeignValue.Location = new System.Drawing.Point(171, 48);
            this.nudForeignValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudForeignValue.Name = "nudForeignValue";
            this.nudForeignValue.Size = new System.Drawing.Size(120, 20);
            this.nudForeignValue.TabIndex = 1;
            this.nudForeignValue.ValueChanged += new System.EventHandler(this.nudForeignValue_ValueChanged);
            // 
            // lblLocalOwed
            // 
            this.lblLocalOwed.AutoSize = true;
            this.lblLocalOwed.Location = new System.Drawing.Point(168, 79);
            this.lblLocalOwed.Name = "lblLocalOwed";
            this.lblLocalOwed.Size = new System.Drawing.Size(39, 13);
            this.lblLocalOwed.TabIndex = 2;
            this.lblLocalOwed.Text = "R 0.00";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(102, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(12, 19);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(52, 13);
            this.lblCurrency.TabIndex = 4;
            this.lblCurrency.Text = "Currency:";
            // 
            // lblCurrencyToBuy
            // 
            this.lblCurrencyToBuy.AutoSize = true;
            this.lblCurrencyToBuy.Location = new System.Drawing.Point(12, 50);
            this.lblCurrencyToBuy.Name = "lblCurrencyToBuy";
            this.lblCurrencyToBuy.Size = new System.Drawing.Size(119, 13);
            this.lblCurrencyToBuy.TabIndex = 5;
            this.lblCurrencyToBuy.Text = "Currency Value To Buy:";
            // 
            // lblLocalValueOwed
            // 
            this.lblLocalValueOwed.AutoSize = true;
            this.lblLocalValueOwed.Location = new System.Drawing.Point(12, 79);
            this.lblLocalValueOwed.Name = "lblLocalValueOwed";
            this.lblLocalValueOwed.Size = new System.Drawing.Size(112, 13);
            this.lblLocalValueOwed.TabIndex = 6;
            this.lblLocalValueOwed.Text = "Local Currency Owed:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(228, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 50);
            this.panel1.TabIndex = 8;
            // 
            // CurrencyPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 217);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblLocalValueOwed);
            this.Controls.Add(this.lblCurrencyToBuy);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblLocalOwed);
            this.Controls.Add(this.nudForeignValue);
            this.Controls.Add(this.cmbCurrency);
            this.Name = "CurrencyPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Makuru Curency Exchange";
            this.Load += new System.EventHandler(this.CurrencyPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeignValue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCurrency;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.NumericUpDown nudForeignValue;
        private System.Windows.Forms.Label lblLocalOwed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblCurrencyToBuy;
        private System.Windows.Forms.Label lblLocalValueOwed;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}

