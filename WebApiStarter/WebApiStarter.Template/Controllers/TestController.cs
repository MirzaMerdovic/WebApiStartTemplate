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
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new List<string> {"Test 1", "Test 2"});
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(id * id);
        }
    }
}
