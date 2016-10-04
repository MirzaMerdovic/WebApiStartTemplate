using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;
using WebApiStarter.Template.App_Start;

[assembly: OwinStartup(typeof(WebApiStarter.Template.Startup))]

namespace WebApiStarter.Template
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.UseErrorPage();

            var configuration = new HttpConfiguration();

            var container = BuildAutofacContainer(configuration);
            app.UseAutofacMiddleware(container);

            ConfigureFormatters(configuration);
            ConfigureRoute(configuration);
            ConfigureServices(configuration);

            app.UseWebApi(configuration);
        }

        private static IContainer BuildAutofacContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Other components can be registered here.

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void ConfigureFormatters(HttpConfiguration configuration)
        {
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }

        private static void ConfigureRoute(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "NotFound",
                routeTemplate: "{*path}",
                defaults: new { controller = "Error", action = "NotFound" }
                );
        }

        private static void ConfigureServices(HttpConfiguration configuration)
        {
            configuration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
            configuration.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());
        }
    }
}