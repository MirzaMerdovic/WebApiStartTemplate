using System.Collections.Generic;
using System.Web.Http;

namespace WebApiStarter.Template.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("values")]
        public IHttpActionResult Get()
        {
            return Ok(new List<int> {1, 2, 3});
        }

        [HttpGet]
        [Route("values/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }
    }
}