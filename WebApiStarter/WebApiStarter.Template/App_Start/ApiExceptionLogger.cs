using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using WebApiStarter.Template.Models;

namespace WebApiStarter.Template.App_Start
{
    /// <summary>
    /// Represents implementation of <see cref="ExceptionLogger"/>.
    /// </summary>
    public class ApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            // Use a logger of your choice to log a request.
            var request = CreateRequest(context.Request);
        }

        private static HttpRequestModel CreateRequest(HttpRequestMessage message)
        {
            var request = new HttpRequestModel
            {
                Body = message.Content.ReadAsStringAsync().Result,
                Method = message.Method.Method,
                Scheme = message.RequestUri.Scheme,
                Host = message.RequestUri.Host,
                Protocol = string.Empty,
                PathBase = message.RequestUri.PathAndQuery,
                Path = message.RequestUri.AbsoluteUri,
                QueryString = message.RequestUri.Query
            };

            return request;
        }
    }
}