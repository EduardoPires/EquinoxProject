using System;
using Equinox.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.UI.Web.Extensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}