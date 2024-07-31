using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.Infra.CrossCutting.Identity
{
    public static class WebAppIdentityConfig
    {
        public static void AddWebAppIdentityConfiguration(this WebApplicationBuilder builder)
        {
            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            builder.Services.AddIdentityEntityFrameworkContextConfiguration(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Equinox.Infra.CrossCutting.Identity")));

            // This is for configure the mapping identity pages routes 
            builder.Services.AddIdentityCore<IdentityUser>().AddDefaultUI();

            // Default Identity configuration from NetDevPack.Identity
            builder.Services.AddIdentityConfiguration();
        }
    }    
}