using Makuru.Models.Database;
using System;
using Makuru.DatabaseStore;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.DataAccess.Implementation
{
    public class ExchangeRateCacheAccess : BaseDataAccess<ExchangeRateCache>
    {
        public ExchangeRateCacheAccess()
        {

        }

        public override ExchangeRateCache Get(Guid id)
        {
            var queryResult = base.Get(id);            
            return queryResult;
        }

        public override IList<ExchangeRateCache> GetAll()
        {
            using (MakuruContext context = new MakuruContext())
            {
                var query = context.ExchangeRateCache.Where(c => c.IsDeleted == false).Include(c => c.FromCurrency).ToList();
                return query;
            }
        }

    }
}
