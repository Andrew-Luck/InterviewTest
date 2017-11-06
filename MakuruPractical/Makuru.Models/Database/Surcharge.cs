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
    public class Surcharge : ISurcharge
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CurrencyId { get ; set ; }

        public decimal Value { get ; set ; }

        public DateTime DateCreated { get ; set ; }

        public bool IsDeleted { get ; set ; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
