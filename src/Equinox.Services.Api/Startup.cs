using Equinox.Infra.CrossCutting.Identity;
using Equinox.Services.Api.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Identity;
using NetDevPack.Identity.User;

namespace Equinox.Services.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // WebAPI Config
            services.AddControllers();

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration);

            // ASP.NET Identity Settings & JWT
            services.AddApiIdentityConfiguration(Configuration);

            // Interactive AspNetUser (logged in)
            // NetDevPack.Identity dependency
            services.AddAspNetUserConfiguration();

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();
        }
    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            // NetDevPack.Identity dependency
            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
