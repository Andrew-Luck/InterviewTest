using Makuru.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Makuru.WebApi.Controllers
{
    [RoutePrefix("api/Surcharge")]
    public class SurchargeController : ApiController
    {
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetSurcharge(Guid id)
        {
            var surchargeAccess = new SurchargeAccess();
            var result = surchargeAccess.Get(id);

            return base.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetSurcharges()
        {
            var surchargeAccess = new SurchargeAccess();
            var result = surchargeAccess.GetAll();

            return base.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult SaveSurcharge([FromBody] dynamic model)
        {
            var surchargeAccess = new SurchargeAccess();
            var result = surchargeAccess.Insert(model);

            return base.Ok();
        }
    }
}
