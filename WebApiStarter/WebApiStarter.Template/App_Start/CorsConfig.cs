using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin.Cors;

namespace WebApiStarter.Template.App_Start
{
    /// <summary>
    /// Represents CORS configuration.
    /// </summary>
    public class CorsConfig
    {
        /// <summary>
        /// Instance of <see cref="CorsOptions"/> that is set to allow all by default.
        /// </summary>
        public static CorsOptions Options = CorsOptions.AllowAll;

        /// <summary>
        /// Initializes and configures <see cref="CorsOptions"/> instance.
        /// </summary>
        /// <param name="origins">String of allowed origins delimited by: ';'</param>
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