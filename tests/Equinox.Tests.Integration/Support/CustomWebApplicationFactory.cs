using Equinox.Infra.CrossCutting.Identity.Data;
using Equinox.Infra.Data.Context;
using Equinox.Services.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.Tests.Integration.Support;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            // Remove existing DbContexts
            var dbContextDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<EquinoxContext>));
            if (dbContextDescriptor != null) services.Remove(dbContextDescriptor);

            var eventStoreDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<EventStoreSqlContext>));
            if (eventStoreDescriptor != null) services.Remove(eventStoreDescriptor);

            var identityDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<EquinoxIdentityContext>));
            if (identityDescriptor != null) services.Remove(identityDescriptor);

            // Add in-memory databases for testing
            services.AddDbContext<EquinoxContext>(options =>
                options.UseInMemoryDatabase("EquinoxTest"));
            services.AddDbContext<EventStoreSqlContext>(options =>
                options.UseInMemoryDatabase("EquinoxTestStore"));
            services.AddDbContext<EquinoxIdentityContext>(options =>
                options.UseInMemoryDatabase("EquinoxTestIdentity"));

            // Add test authentication
            services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });

            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            scope.ServiceProvider.GetRequiredService<EquinoxContext>().Database.EnsureCreated();
            scope.ServiceProvider.GetRequiredService<EventStoreSqlContext>().Database.EnsureCreated();
            scope.ServiceProvider.GetRequiredService<EquinoxIdentityContext>().Database.EnsureCreated();
        });
    }
}
