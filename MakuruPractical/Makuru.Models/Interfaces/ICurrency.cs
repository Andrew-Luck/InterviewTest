using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Interfaces
{
    public interface ICurrency : IBaseModel
    {
        string Code { get; set; }

        string Description { get; set; }

        string ISOCode { get; set; }
    }
}
