using Makuru.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Interfaces
{
    public interface IOrderAction : IBaseModel
    {
        Enums.OrderActions OrderActionId { get; set; }

        string Value { get; set; }

        Guid CurrencyId { get; set; }
        
        Currency Currency { get; set; }
    }
}
