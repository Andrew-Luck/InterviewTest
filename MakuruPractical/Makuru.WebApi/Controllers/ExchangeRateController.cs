using Makuru.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Makuru.WebApi.Controllers
{
    public class ExchangeRateController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetExchangeRate(Guid id)
        {
            var exchangeRateCacheAccess = new ExchangeRateCacheAccess();
            var result = exchangeRateCacheAccess.Get(id);

            return base.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetExchangeRate()
        {
            var exchangeRateCacheAccess = new ExchangeRateCacheAccess();
            var result = exchangeRateCacheAccess.GetAll();

            return base.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult SaveExchangeRate([FromBody] dynamic model)
        {
            var exchangeRateCacheAccess = new ExchangeRateCacheAccess();
            var result = exchangeRateCacheAccess.Insert(model);

            return base.Ok();
        }
    }
}
