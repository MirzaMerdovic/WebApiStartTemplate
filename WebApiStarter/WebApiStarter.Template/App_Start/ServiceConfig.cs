using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace WebApiStarter.Template.App_Start
{
    public class ServiceConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
            configuration.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());
        }
    }
}