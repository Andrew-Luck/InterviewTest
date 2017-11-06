namespace Makuru.DatabaseStore
{
    using Makuru.Models.Database;
    using Makuru.Models.Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MakuruContext : DbContext
    {
        public MakuruContext()
            : base("name=MakuruContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        public virtual IDbSet<Currency> Currencies { get; set; }

        public virtual IDbSet<ExchangeRateHistories> ExchangeRateHistories { get; set; }

        public virtual IDbSet<ExchangeRateCache> ExchangeRateCache { get; set; }

        public virtual IDbSet<CompletedTransaction> CompletedTransactions { get; set; }

        public virtual IDbSet<Surcharge> Surcharges { get; set; }

        public virtual IDbSet<OrderAction> OrderActions { get; set; }
    }
}