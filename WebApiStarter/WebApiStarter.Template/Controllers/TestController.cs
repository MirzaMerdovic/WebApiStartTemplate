using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiStarter.Template.Controllers
{
    /// <summary>
    /// Represents test controller that should be removed.
    /// </summary>
    [RoutePrefix("v1/test")]
    public class TestController : ApiController
    {
        [HttpPost, Route(""), ResponseType(typeof(int))]
        public IHttpActionResult Post(string value)
        {
            var id = new Random().Next();

            return CreatedAtRoute("GetById", new { id }, id);
        }

        [HttpGet, Route(""), ResponseType(typeof(List<string>))]
        public IHttpActionResult Get()
        {
            return Ok(new List<string> {"Test 1", "Test 2"});
        }

        [HttpGet, Route("{id:int}", Name = "GetById"), ResponseType(typeof(int))]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return NotFound();

            return Ok(id * id);
        }
    }
}
