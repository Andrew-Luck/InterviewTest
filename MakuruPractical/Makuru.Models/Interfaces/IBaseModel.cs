using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Interfaces
{
    public interface IBaseModel
    {
        Guid Id { get; set; }

        DateTime DateCreated { get; set; }

        bool IsDeleted { get; set; }
    }
}
