using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin.Cors;

namespace WebApiStarter.Template.App_Start
{
    public class CorsConfig
    {
        public static CorsOptions Options = CorsOptions.AllowAll;

        public static void ConfigureCors(string origins)
        {
            if (string.IsNullOrWhiteSpace(origins))
                return;

            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            corsPolicy.Origins.ToList().AddRange(origins.Split(';'));

            if (!corsPolicy.Origins.Any())
                return;

            Options = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };
        }
    }
}