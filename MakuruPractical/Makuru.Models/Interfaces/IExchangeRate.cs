using Makuru.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Interfaces
{
    public interface IExchangeRate : IBaseModel
    {
        Guid FromCurrencyId { get; set; }

        Guid ToCurrencyId { get; set; }

        decimal Value { get; set; }

        Currency FromCurrency { get; set; }

        Currency ToCurrency { get; set; }
    }
}
