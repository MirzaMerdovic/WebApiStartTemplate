using System.Web.Http;

namespace WebApiStarter.Template.App_Start
{
    public class RouteConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "NotFound",
                routeTemplate: "{*path}",
                defaults: new { controller = "Error", action = "NotFound" });
        }
    }
}