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
    [Table("Currency")]
    public class Currency : ICurrency
    {
        [Key]
        public Guid Id { get; set; }

        public string Code { get ; set ; }

        public string Description { get ; set ; }

        public string ISOCode { get ; set ; }

        public DateTime DateCreated { get ; set ; }

        public bool IsDeleted { get ; set ; }
    }
}
