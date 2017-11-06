using Makuru.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makuru.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Makuru.Models.Database
{
    public class OrderAction : IOrderAction
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public Enums.OrderActions OrderActionId { get; set; }

        public string Value { get; set; }

        public Guid CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
