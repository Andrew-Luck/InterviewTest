using Makuru.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Makuru.WebApi.Controllers
{
    public class OrderActionController : ApiController
    {
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetOrderAction(Guid id)
        {
            var orderActionAccess = new OrderActionAccess();
            var result = orderActionAccess.Get(id);

            return base.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetOrderActions()
        {
            var orderActionAccess = new OrderActionAccess();
            var result = orderActionAccess.GetAll();

            return base.Ok(result);
        }
    }
}
