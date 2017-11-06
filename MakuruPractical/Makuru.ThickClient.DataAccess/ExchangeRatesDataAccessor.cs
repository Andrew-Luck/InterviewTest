using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.ThickClient.DataAccess
{
    public class ExchangeRatesDataAccessor : BaseDataAccessor
    {
        public ExchangeRatesDataAccessor(string baseUri) : base(baseUri)
        {
            base.Resource = "ExchangeRate";
        }
    }
}
