using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiStarter.Template.Models;

namespace WebApiStarter.Template.Controllers
{
    /// <summary>
    /// Represents controller that exposes routes for error viewing.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ApiController
    {
        /// <summary>
        /// Intercepts rout not found error in order to show it as friendly message on the screen.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>404 with <see cref="ErrorInfoModel"/> object as content.</returns>
        [HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete, HttpHead, HttpOptions]
        public HttpResponseMessage NotFound(string path)
        {
            var metadata = new ErrorInfoModel
            {
                Message = "Route doesn't exist.",
                TimeStamp = DateTime.UtcNow,
                RequestUri = Request.RequestUri,
                ErrorId = Request.GetCorrelationId()
            };

            return Request.CreateResponse(HttpStatusCode.NotFound, metadata);
        }
    }
}