using Equinox.Infra.CrossCutting.IoC;

namespace Equinox.UI.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            NativeInjectorBootStrapper.RegisterServices(builder);
        }
    }
}