﻿using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using $safeprojectname$.App_Start;

[assembly: OwinStartup(typeof($safeprojectname$.Template.Startup))]
namespace $safeprojectname$.Template
{
    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            new ApiConfig(app)
                .ConfigureCorsMiddleware(ConfigurationManager.AppSettings["cors"])
                .ConfigureAufacMiddleware()
                .ConfigureFormatters()
                .ConfigureRoutes()
                .ConfigureExceptionHandling()
                .ConfigureSwagger()
                .UseWebApi();
        }
    }
}