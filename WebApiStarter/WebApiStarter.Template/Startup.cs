using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebApiStarter.Template.App_Start;

[assembly: OwinStartup(typeof(WebApiStarter.Template.Startup))]

namespace WebApiStarter.Template
{
    /// <summary>
    /// OWIN Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            CorsConfig.ConfigureCors(ConfigurationManager.AppSettings["cors"]);
            app.UseCors(CorsConfig.Options);

            var configuration = new HttpConfiguration();

            AutofacConfig.Configure(configuration);
            app.UseAutofacMiddleware(AutofacConfig.Container);

            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);
            ServiceConfig.Configure(configuration);

            app.UseWebApi(configuration);
        }
    }
}