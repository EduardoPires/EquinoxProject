using Equinox.Application.Interfaces;
using Equinox.Application.Services;
using Equinox.Domain.Commands;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Events;
using Equinox.Domain.Interfaces;
using Equinox.Infra.CrossCutting.Bus;
using Equinox.Infra.Data.Context;
using Equinox.Infra.Data.EventSourcing;
using Equinox.Infra.Data.Repository;
using Equinox.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Equinox.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            // Domain Bus (Mediator)
            builder.Services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            builder.Services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            builder.Services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            builder.Services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            builder.Services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            // Infra - Data
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<EquinoxContext>();

            // Infra - Data EventSourcing
            builder.Services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            builder.Services.AddScoped<IEventStore, SqlEventStore>();
            builder.Services.AddScoped<EventStoreSqlContext>();
        }
    }
}