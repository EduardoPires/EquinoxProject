using Equinox.Domain.CommandHandlers;
using Equinox.Domain.Commands;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.EventHandlers;
using Equinox.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.Infra.CrossCutting.IoC.Modules
{
    public class DomainModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();
        }
    }
}
