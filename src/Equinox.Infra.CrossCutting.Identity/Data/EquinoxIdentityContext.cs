using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace Equinox.Infra.CrossCutting.Identity.Data
{
    public class EquinoxIdentityContext : IdentityDbContext
    {
        public EquinoxIdentityContext(DbContextOptions<EquinoxIdentityContext> options) : base(options) { }
    }

    public class EquinoxIdentityContextFactory : IDesignTimeDbContextFactory<EquinoxIdentityContext>
    {
        public EquinoxIdentityContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<EquinoxIdentityContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (environment == "Development")
            {
                builder.UseSqlite(connectionString);
            }
            else
            {
                builder.UseSqlServer(connectionString);
            }                

            return new EquinoxIdentityContext(builder.Options);
        }
    }
}