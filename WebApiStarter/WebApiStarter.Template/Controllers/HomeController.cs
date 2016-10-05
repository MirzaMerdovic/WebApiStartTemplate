using System.Web.Http;

namespace WebApiStarter.Template.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Web API Started successfully";
        }
    }
}