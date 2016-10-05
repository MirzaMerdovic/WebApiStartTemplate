using System.Collections.Generic;
using System.Web.Http;

namespace WebApiStarter.Template.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("values")]
        public IHttpActionResult Get()
        {
            return Ok(new List<int> {1, 2, 3});
        }
    }
}