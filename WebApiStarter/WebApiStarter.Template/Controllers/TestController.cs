using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiStarter.Template.Controllers
{
    /// <summary>
    /// Represents test controller that should be removed.
    /// </summary>
    [RoutePrefix("v1/test")]
    public class TestController : ApiController
    {
        [HttpPost, Route("")]
        public IHttpActionResult Post(string value)
        {
            var id = new Random().Next();

            return CreatedAtRoute("GetById", new { id }, id);
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new List<string> {"Test 1", "Test 2"});
        }

        [HttpGet, Route("{id:int}", Name = "GetById")]
        public IHttpActionResult Get(int id)
        {
            return Ok(id * id);
        }
    }
}
