using Makuru.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Interfaces
{
    public interface ISurcharge : IBaseModel
    {
        Guid CurrencyId { get; set; }

        decimal Value { get; set; }

        Currency Currency { get; set; }
    }
}
