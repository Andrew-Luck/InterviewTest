using Makuru.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Makuru.WebApi.Controllers
{
    public class CurrencyController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCurrency(Guid id)
        {
            var currencyAccess = new CurrencyAccess();
            var result = currencyAccess.Get(id);

            return base.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetCurrencies()
        {
            var currencyAccess = new CurrencyAccess();
            var result = currencyAccess.GetAll();

            return base.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult SaveCurrencies([FromBody] dynamic model)
        {
            var currencyAccess = new CurrencyAccess();
            var result = currencyAccess.Insert(model);

            return base.Ok();
        }
    }
}
