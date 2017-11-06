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
    public class CompletedTransaction : ICompletedTransaction
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ExchangeRateId { get ; set ; }

        public Guid SurchargeId { get ; set ; }

        public decimal ForeignValue { get ; set ; }

        public decimal LocalValue { get ; set ; }

        public decimal ExchangeRateValue { get; set; }

        public decimal SurchargePercent { get; set; }   

        public decimal SurchargeValue { get; set; }

        public decimal Discount { get; set; }

        public DateTime DateCreated { get ; set ; }

        public bool IsDeleted { get ; set ; }

        [ForeignKey("ExchangeRateId")]
        public ExchangeRateHistories ExchangeRate { get; set; }

        [ForeignKey("SurchargeId")]
        public Surcharge Surcharge { get; set; }
    }
}
