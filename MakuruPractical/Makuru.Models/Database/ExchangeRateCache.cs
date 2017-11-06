using Makuru.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Database
{
    public class ExchangeRateCache : IExchangeRate
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid FromCurrencyId { get ; set ; }

        public Guid ToCurrencyId { get ; set ; }

        public decimal Value { get ; set ; }

        public DateTime DateCreated { get ; set ; }

        public bool IsDeleted { get ; set ; }

        [ForeignKey("FromCurrencyId")]
        public Currency FromCurrency { get; set; }

        [ForeignKey("ToCurrencyId")]
        public Currency ToCurrency { get; set; }
    }
}
