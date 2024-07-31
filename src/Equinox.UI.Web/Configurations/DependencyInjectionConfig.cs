using Equinox.Infra.CrossCutting.IoC;

namespace Equinox.UI.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            NativeInjectorBootStrapper.RegisterServices(builder);
        }
    }
}