using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebApiStarter.Template.App_Start
{
    public static class FormatterConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}