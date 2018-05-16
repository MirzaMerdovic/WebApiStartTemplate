using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using WebApiStarter.Template.Models;

namespace WebApiStarter.Template.App_Start
{
    /// <summary>
    /// Represents implementation of <see cref="ExceptionLogger"/>.
    /// </summary>
    public class ApiExceptionLogger : ExceptionLogger
    {
        /// <summary>
        /// Overrides <see cref="ExceptionLogger.LogAsync"/> method with custom logger implementations.
        /// </summary>
        /// <param name="context">Instance of <see cref="ExceptionLoggerContext"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            var request = await CreateRequest(context.Request);
            // Use a logger of your choice to log a request.
        }

        private static async Task<HttpRequestModel> CreateRequest(HttpRequestMessage message)
        {
            var request = new HttpRequestModel
            {
                Body = await ReadContent(message.Content).ConfigureAwait(false),
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

        private static async Task<string> ReadContent(HttpContent content)
        {
            using (content)
            {
                string body;
                try
                {
                    body = await content.ReadAsStringAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    body = $"Failed to read body. Error: {e}";
                }

                return body;
            }
        }
    }
}