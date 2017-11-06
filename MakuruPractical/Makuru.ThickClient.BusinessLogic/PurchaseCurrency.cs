using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makuru.Models.Database;
using Makuru.Models.Interfaces;
using Makuru.ThickClient.DataAccess;

namespace Makuru.ThickClient.BusinessLogic
{
    public class PurchaseCurrency
    {
        private string baseUri;
        private decimal? discount;

        public List<ExchangeRateCache> ExchangeRates { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Surcharge> Surcharges { get; set; }
        public List<OrderAction> OrderActions { get; set; }

        public PurchaseCurrency(string baseUri)
        {
            this.baseUri = baseUri;
            getExchangeRates();
            getCurrencyList();
            getSurchargeList();
            getActionList();
        }

        private void getExchangeRates()
        {
            DataAccess.ExchangeRatesDataAccessor exchangeDataAccessor = new DataAccess.ExchangeRatesDataAccessor(baseUri);
            ExchangeRates = exchangeDataAccessor.GetData<List<ExchangeRateCache>>();
        }

        private void getCurrencyList()
        {
            DataAccess.CurrencyDataAccessor currencyDataAccessor = new DataAccess.CurrencyDataAccessor(baseUri);
            Currencies = currencyDataAccessor.GetData<List<Currency>>();
        }

        private void getSurchargeList()
        {
            DataAccess.SurchargeDataAccessor surchargeDataAccessor = new DataAccess.SurchargeDataAccessor(baseUri);
            Surcharges = surchargeDataAccessor.GetData<List<Surcharge>>();
        }

        private void getActionList()
        {
            DataAccess.OrderActionDataAccessor orderActionDataAccessor = new DataAccess.OrderActionDataAccessor(baseUri);
            OrderActions = orderActionDataAccessor.GetData<List<OrderAction>>();
        }

        private IExchangeRate getExchangeRateFromForeignId(Guid foreignCurrencyId)
        {
            var currencyExchange = ExchangeRates.FirstOrDefault(c => c.ToCurrencyId == foreignCurrencyId);
            return currencyExchange;
        }

        private ISurcharge getSurchargeFromCurrencyId(Guid currencyId)
        {
            var surcharge = Surcharges.FirstOrDefault(c => c.CurrencyId == currencyId);
            return surcharge;
        }

        private ICurrency getCurrencyFromId(Guid currencyId)
        {
            var currency = Currencies.FirstOrDefault(c => c.Id == currencyId);
            return currency;
        }

        private bool saveTransaction(Guid currencyId, decimal value)
        {
            var currencyExchange = getExchangeRateFromForeignId(currencyId);
            var surcharge = Surcharges.FirstOrDefault(c => c.CurrencyId == currencyId);

            ICompletedTransaction transaction = new CompletedTransaction();
            transaction.ExchangeRateId = currencyExchange.Id;
            transaction.LocalValue = CalculateLocalOwedAmount(currencyId, value);
            transaction.ForeignValue = value;
            transaction.ExchangeRateValue = currencyExchange.Value;
            transaction.SurchargeId = surcharge.Id;
            transaction.SurchargePercent = surcharge.Value;
            transaction.SurchargeValue = value * (1 + surcharge.Value);

            if (discount.HasValue)
                transaction.Discount = discount.Value;

            if (discount.HasValue)
                transaction.LocalValue = transaction.LocalValue / (1 + discount.Value);

            CompletedTransactionDataAccessor completedTransactionAccessor = new CompletedTransactionDataAccessor(baseUri);
            var saveResult = completedTransactionAccessor.Insert(transaction);
            return saveResult;
        }

        private string processOrderActions(Guid currencyId, decimal value)
        {
            var stringBuilder = new StringBuilder();
            var orderActions = getOrderAction(currencyId);
            foreach (var orderAction in orderActions)
            {
                switch (orderAction.OrderActionId)
                {
                    case Models.Enums.OrderActions.None:
                        break;
                    case Models.Enums.OrderActions.Discount:
                        discount = Convert.ToDecimal(orderAction.Value);
                        stringBuilder.AppendLine("A discount has been applied");
                        break;
                    case Models.Enums.OrderActions.SendEmail:
                        sendEmail(orderAction.Value, currencyId, value);
                        break;
                }
            }

            return stringBuilder.ToString();
        }

        private void sendEmail(string baseEmailTemplate, Guid currencyId, decimal value)
        {
            var email = string.Format(baseEmailTemplate, string.Format("Selected currency: {0}\nSelected amount: {1}\nAmount owed: {2}", getCurrencyFromId(currencyId).Code, value, CalculateLocalOwedAmount(currencyId, value)));
            EmailHelper.SendEmail(email, "Order Information");
        }

        private List<OrderAction> getOrderAction(Guid currencyId)
        {
            var orderActionList = OrderActions.Where(c => c.CurrencyId == currencyId).ToList();
            return orderActionList;
        }

        public decimal CalculateLocalOwedAmount(Guid currencyId, decimal value)
        {
            var currencyExchange = getExchangeRateFromForeignId(currencyId);
            var surcharge = Surcharges.FirstOrDefault(c => c.CurrencyId == currencyId);
            if (currencyExchange == null || currencyExchange.Value == decimal.Zero)
                return 0;

            var calculatedAmount = value / (currencyExchange.Value);

            if (surcharge != null)
            {
                calculatedAmount = calculatedAmount * (1 + surcharge.Value);
            }

            return calculatedAmount;
        }

        public string CompleteOrder(Guid currencyId, decimal value)
        {
            string result = string.Empty;
            var validateInputResult = isValueValid(value);
            var validateOptionResult = selectedCurrencyHasExchangeRate(currencyId);

            if (!validateInputResult)
                return "Please enter a value greater than 0";

            if (!validateOptionResult)
                return "Please select another foreign currency";

            var actionResult = processOrderActions(currencyId, value);
            var saveResult = saveTransaction(currencyId, value);

            if (saveResult)
            {
                result = string.Format("{0}\n{1}", "Order Saved Successfully.", actionResult);
            }
            else
            {
                throw new Exception("Order has not been saved.");
            }


            return result;
        }

        private bool selectedCurrencyHasExchangeRate(Guid currencyId)
        {
            var exchangeRate = getExchangeRateFromForeignId(currencyId);
            if (exchangeRate == null)
                return false;

            return true;
        }

        private bool isValueValid(decimal value)
        {
            return value > 0;
        }

        public void Clear()
        {
            discount = null;

        }
    }
}
