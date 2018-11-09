using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApiStarter.App_Start
{
    /// <summary>
    /// Represents implementation of <see cref="ExceptionLogger"/>.
    /// </summary>
    public class ApiExceptionLogger : ExceptionLogger
    {
        private const string CorrelationIdHeaderName = "CorrelationId";

        /// <summary>
        /// Overrides <see cref="ExceptionLogger.LogAsync"/> method with custom logger implementations.
        /// </summary>
        /// <param name="context">Instance of <see cref="ExceptionLoggerContext"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            GetOrSetCorrelationId(context.Request);
            var request = await CreateRequest(context.Request);
            // Use a logger of your choice to log a request.

            void GetOrSetCorrelationId(HttpRequestMessage message)
            {
                var correlationId = Guid.NewGuid().ToString();

                if (!message.Headers.TryGetValues(CorrelationIdHeaderName, out var correlations))
                {
                    message.Headers.Add(CorrelationIdHeaderName, correlationId);
                }
                else if (Guid.TryParse(correlations.First(), out var id))
                {
                    message.Headers.Add(CorrelationIdHeaderName, id.ToString());
                }
                else
                {
                    message.Headers.Add(CorrelationIdHeaderName, correlationId);
                }
            }
        }

        private static async Task<dynamic> CreateRequest(HttpRequestMessage message)
        {
            var request = new
            {
                CorrelationId = message.Headers.GetValues(CorrelationIdHeaderName).First(),
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

            async Task<string> ReadContent(HttpContent content)
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
}