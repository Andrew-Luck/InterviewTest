using Makuru.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Interfaces
{
    public interface ICompletedTransaction : IBaseModel
    {
        Guid ExchangeRateId { get; set; }

        Guid SurchargeId { get; set; }

        decimal ForeignValue { get; set; }

        decimal LocalValue { get; set; }

        decimal ExchangeRateValue { get; set; }

        decimal SurchargePercent { get; set; }

        decimal SurchargeValue { get; set; }

        decimal Discount { get; set; }

        ExchangeRateHistories ExchangeRate { get; set; }

        Surcharge Surcharge { get; set; }
    }
}
