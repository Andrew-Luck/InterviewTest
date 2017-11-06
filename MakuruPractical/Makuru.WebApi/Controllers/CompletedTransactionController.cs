using Makuru.DataAccess.Implementation;
using Makuru.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Makuru.WebApi.Controllers
{
    [RoutePrefix("api/CompletedTransaction")]
    public class CompletedTransactionController : ApiController
    {
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetCompletedTransaction(Guid id)
        {
            var completedTransactionAccess = new CompletedTransactionAccess();
            var result = completedTransactionAccess.Get(id);

            return base.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult SaveCompletedTransaction([FromBody] CompletedTransaction model)
        {
            if (!(model is CompletedTransaction))
                return base.BadRequest();

            var completedTransactionAccess = new CompletedTransactionAccess();
            var result = completedTransactionAccess.Insert(model);

            return base.Ok();
        }
    }
}
