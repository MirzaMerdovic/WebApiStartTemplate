using System.Web.Http;
using System.Xml.XPath;
using Swashbuckle.Application;

namespace Compusight.MoveDesk.UserManagementApi.Configuration
{
    /// <summary>
    /// Represent Swagger configuration.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Configures Swagger API 
        /// </summary>
        /// <param name="configuration">Instance of <see cref="HttpConfiguration"/>.</param>
        public static void Configure(HttpConfiguration configuration)
        {
            configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "My.Api");
                    c.PrettyPrint();
                    c.IncludeXmlComments(() => new XPathDocument($@"{System.AppDomain.CurrentDomain.BaseDirectory}bin\WebApiStarter.Template.xml"));
                })
                .EnableSwaggerUi(c => { });
        }
    }
}