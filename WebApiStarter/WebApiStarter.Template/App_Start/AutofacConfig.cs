using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace WebApiStarter.Template.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Container;

        public static void Configure(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Other components can be registered here.

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}