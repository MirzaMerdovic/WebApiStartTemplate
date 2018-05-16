using System;
using System.Net;
using System.Net.Http;
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
        /// <param name="context">Instance fo <see cref="ExceptionHandlerContext"/>.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            var correlationId = Guid.NewGuid();

            var metadata = new ErrorInfoModel
            {
                Message = "An unexpected error occurred! Please use the Error ID to contact support",
                TimeStamp = DateTime.UtcNow,
                RequestUri = context.Request.RequestUri,
                ErrorId = correlationId
            };

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
            context.Result = new ResponseMessageResult(response);
        }
    }
}