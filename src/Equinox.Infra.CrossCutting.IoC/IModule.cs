using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.Infra.CrossCutting.IoC
{
    public interface IModule
    {
        /// <summary>
        /// Works just like the web StartUp.ConfigureServices of WebApp StartUp class.
        /// </summary>
        /// <param name="services">A service colletion to be provided StartUp application</param>
        /// <param name="configuration">A Configuration to be provided StartUp application</param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}