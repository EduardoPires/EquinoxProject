using Equinox.Infra.CrossCutting.IoC;

namespace Equinox.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            NativeInjectorBootStrapper.RegisterServices(builder);

            return builder;
        }
    }
}