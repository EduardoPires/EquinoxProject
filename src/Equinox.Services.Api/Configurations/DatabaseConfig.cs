using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static WebApplicationBuilder AddDatabaseConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            if (builder.Environment.EnvironmentName == "Testing")
            {
                builder.Services.AddDbContext<EquinoxContext>(options =>
                    options.UseInMemoryDatabase("Equinox"));
                builder.Services.AddDbContext<EventStoreSqlContext>(options =>
                    options.UseInMemoryDatabase("EquinoxEvents"));
            }
            else
            {
                builder.Services.AddDbContext<EquinoxContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                builder.Services.AddDbContext<EventStoreSqlContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            }

            return builder;
        }
    }
}