using Equinox.Domain.Core.Events;
using Equinox.Domain.Events;
using Equinox.Domain.Models;
using Equinox.Infra.CrossCutting.Identity.Data;
using Equinox.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;
using Newtonsoft.Json;

namespace Equinox.UI.Web.Configurations
{
    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<EquinoxContext>();
            var contextStore = scope.ServiceProvider.GetRequiredService<EventStoreSqlContext>();
            var contextIdentity = scope.ServiceProvider.GetRequiredService<EquinoxIdentityContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                await context.Database.MigrateAsync();
                await contextStore.Database.MigrateAsync();
                await contextIdentity.Database.MigrateAsync();

                await EnsureSeedProducts(context, contextStore, contextIdentity);
            }
        }

        private static async Task EnsureSeedProducts(EquinoxContext context, 
                                                     EventStoreSqlContext contextStore,
                                                     EquinoxIdentityContext contextIdentity)
        {
            if (contextIdentity.Users.Any())
                return;

            var userId = Guid.NewGuid();

            await contextIdentity.Users.AddAsync(new IdentityUser
            {
                Id = userId.ToString(),
                UserName = "teste@teste.com",
                NormalizedUserName = "TESTE@TESTE.COM",
                Email = "teste@teste.com",
                NormalizedEmail = "TESTE@TESTE.COM",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEEdWhqiCwW/jZz0hEM7aNjok7IxniahnxKxxO5zsx2TvWs4ht1FUDnYofR8JKsA5UA==",
                TwoFactorEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            });

            await contextIdentity.UserClaims.AddAsync(new IdentityUserClaim<string>
            {
                UserId = userId.ToString(),
                ClaimType = "Customers",
                ClaimValue = "Write,Remove"
            });

            await contextIdentity.SaveChangesAsync();

            if (context.Customers.Any())
                return;

            var customer = new Customer(
                Guid.NewGuid(),
                "Eduardo Pires",
                "contato@eduardopires.net.br",
                new DateTime(1982, 04, 24));

            await context.Customers.AddAsync(customer);
            
            await context.SaveChangesAsync();

            var customerEvent = new CustomerRegisteredEvent(customer.Id,
                                                            customer.Name,
                                                            customer.Email,
                                                            customer.BirthDate);

            var serializedData = JsonConvert.SerializeObject(customerEvent);

            await contextStore.StoredEvent.AddAsync(new StoredEvent(customerEvent, serializedData, "teste@teste.com"));

            await contextStore.SaveChangesAsync();
        }
    }
}
