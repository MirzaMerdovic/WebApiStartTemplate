using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using WebApiStarter.Template.Models;

namespace WebApiStarter.Template.App_Start
{
    /// <summary>
    /// Represents implementation of <see cref="ExceptionHandler"/>.
    /// </summary>
    public class ApiExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Overrides <see cref="ExceptionHandler.Handle"/> method with code that sets friendly error message to be shown in browser.
        /// </summary>
        /// <param name="context">Instance of <see cref="ExceptionHandlerContext"/>.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var correlationId = context.Request.Headers.GetValues("CorrelationId").First();

            var metadata = new
            {
                Message = "An unexpected error occurred! Please use the Error ID to contact support",
                TimeStamp = DateTime.UtcNow,
                RequestUri = context.Request.RequestUri,
                ErrorId = correlationId
            };

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
            response.Headers.Add("CorrelationId", correlationId);

            context.Result = new ResponseMessageResult(response);
        }
    }
}