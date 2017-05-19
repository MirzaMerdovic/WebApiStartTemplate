using Swashbuckle.Application;
using System.Web.Http;

namespace WebApiStarter.Template.App_Start
{
    /// <summary>
    /// Represents route configuration.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Configures Web API routes.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger"));
        }
    }
}