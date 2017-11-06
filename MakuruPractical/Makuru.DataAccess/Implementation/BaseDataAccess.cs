using Makuru.DataAccess.Interfaces;
using Makuru.DatabaseStore;
using Makuru.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.DataAccess.Implementation
{

    public abstract class BaseDataAccess<TModel> : IBaseDataAccess<TModel> where TModel : class, IBaseModel
    {
        public virtual TModel Get(Guid id)
        {
            using (MakuruContext context = new MakuruContext())
            {
                var model = context.Set<TModel>().Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();
                return model;
            }
        }

        public virtual IList<TModel> GetAll()
        {
            using (MakuruContext context = new MakuruContext())
            {
                var query = context.Set<TModel>().Where(c => c.IsDeleted == false).ToList();
                return query;
            }
        }

        public virtual Guid Insert(TModel model)
        {
            using (MakuruContext context = new MakuruContext())
            {
                if (model.Id == null || model.Id == Guid.Empty)
                    model.Id = Guid.NewGuid();

                model.DateCreated = DateTime.Now;
                model.IsDeleted = false;
                
                context.Set<TModel>().Add(model);
                context.SaveChanges();

                return model.Id;
            }
        }

        public virtual bool Update(TModel model)
        {
            throw new NotImplementedException();
        }        
    }
}
