using System;
using System.CodeDom;
using System.Web.Http;
using System.Xml.XPath;
using Swashbuckle.Application;
using System.Reflection;

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
                    c.IncludeXmlComments(() => new XPathDocument(GetXmlDocumentationPath()));
                })
                .EnableSwaggerUi(c => { });
        }

        private static string GetXmlDocumentationPath()
        {
            var path =
                string.Format("{0}bin\\{1}.xml", AppDomain.CurrentDomain.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name);

            return path;
        }
    }
}