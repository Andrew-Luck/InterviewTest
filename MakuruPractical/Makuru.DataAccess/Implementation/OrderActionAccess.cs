using Makuru.Models.Database;
using System;
using Makuru.DatabaseStore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.DataAccess.Implementation
{
    public class OrderActionAccess : BaseDataAccess<OrderAction>
    {
        public OrderActionAccess()
        {

        }

        public override OrderAction Get(Guid id)
        {
            var queryResult = base.Get(id);            
            return queryResult;
        }
        
    }
}
