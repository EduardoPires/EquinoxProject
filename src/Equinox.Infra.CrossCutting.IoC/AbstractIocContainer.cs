using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.Infra.CrossCutting.IoC
{
    public abstract class AbstractIocContainer
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;

        protected AbstractIocContainer(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        /// <summary>
        /// Register all services, or all modules of system.
        /// </summary>
        /// <remarks>
        /// To use it, you must do something like this
        ///  
        ///  AddModule(new MyModule()); // MyModule : IModule
        /// 
        /// </remarks>
        public abstract void RegisterModules();

        /// <summary>
        /// Given a module, register all it's services
        /// </summary>
        /// <param name="module">A <see cref="IModule"/></param>
        // ReSharper disable once UnusedMember.Local
        protected void RegisterModule(IModule module)
        {
            module.ConfigureServices(_services, _configuration);
        }
    }
}
