using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Makuru.ThickClient.BusinessLogic;

namespace MakuruPractical
{
    public partial class CurrencyPurchase : Form
    {
        PurchaseCurrency logic;
        public CurrencyPurchase()
        {
            InitializeComponent();

            var baseUri = Properties.Settings.Default.ApiBaseUrl;
            logic = new PurchaseCurrency(baseUri);

            bsCurrency.DataSource = logic.Currencies;
            cmbCurrency.DisplayMember = "Code";
            cmbCurrency.ValueMember = "Id";            
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayOwingAmount();
        }

        private void nudForeignValue_ValueChanged(object sender, EventArgs e)
        {
            displayOwingAmount();
        }

        private Guid? getSelectedCurrency()
        {
            if (cmbCurrency.SelectedValue == null)
                return null;

            var selectedCurrency = cmbCurrency.SelectedValue as Guid?;
            return selectedCurrency;
        }

        private decimal getSelectedAmount()
        {
            var selectedAmount = nudForeignValue.Value;
            return selectedAmount;
        }

        private void displayOwingAmount()
        {
            var currencyId = getSelectedCurrency();
            var selectedValue = getSelectedAmount();

            var amountOwed = decimal.Zero;
            if (currencyId.HasValue)
            {
                amountOwed = calculateLocalOwedAmount(currencyId.Value, selectedValue);
            }
            lblLocalOwed.Text = string.Format("R {0}", amountOwed.ToString("#0.00"));
        }

        private decimal calculateLocalOwedAmount(Guid currencyId, decimal value)
        {
            return logic.CalculateLocalOwedAmount(currencyId, value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            try
            {
                var completeOrderResult = logic.CompleteOrder(getSelectedCurrency().Value, getSelectedAmount());

                if (MessageBox.Show(completeOrderResult, "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    clear();
            }
            catch (Exception ex)
            {
                //System.Diagnostics.EventLog.WriteEntry("Makuru Exchange Application", ex.Message);
                var displayMessage = string.Format("There was an error saving your order.\n{0}", ex.Message);
                MessageBox.Show(displayMessage, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear()
        {
            logic.Clear();
            lblLocalOwed.Text = "R 0.00";
            nudForeignValue.Value = decimal.Zero;
        }

        private void CurrencyPurchase_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to exit?", "Exit Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
