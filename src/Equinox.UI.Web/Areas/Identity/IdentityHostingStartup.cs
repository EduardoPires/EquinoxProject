using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Equinox.UI.Web.Areas.Identity.IdentityHostingStartup))]
namespace Equinox.UI.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {});
        }
    }
}