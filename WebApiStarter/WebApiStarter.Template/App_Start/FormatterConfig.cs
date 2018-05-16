using System;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebApiStarter.Template.App_Start
{
    /// <summary>
    /// Represents formatter configuration.
    /// </summary>
    public static class FormatterConfig
    {
        /// <summary>
        /// Configures formatter to use JSON and removes XML formatter.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}