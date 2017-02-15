using Equinox.Domain.Core.Bus;
using Equinox.Infra.CrossCutting.Bus;
using Equinox.Infra.CrossCutting.IoC.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.Infra.CrossCutting.IoC
{
    public class IoCContainer : AbstractIocContainer
    {
        private readonly IServiceCollection _services;

        public IoCContainer(IServiceCollection services, IConfiguration configuration) 
            : base(services, configuration)
        {
            _services = services;
        }

        public override void RegisterModules()
        {
            // ASP.NET HttpContext dependency
            _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            RegisterModule(new IdentityModule());
            RegisterModule(new DataModule());
            RegisterModule(new DomainModule());
            RegisterModule(new ApplicationModule());

            // Infra - Bus
            _services.AddScoped<IBus, InMemoryBus>();
        }
    }
}
