using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.DataAccess.Interfaces
{
    interface IBaseDataAccess<TModel>  where TModel : class
    {
        TModel Get(Guid id);

        IList<TModel> GetAll();

        Guid Insert(TModel model);

        bool Update(TModel model);
    }
}
