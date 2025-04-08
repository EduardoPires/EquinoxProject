using Equinox.Application.Services;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Models;
using Equinox.Infra.CrossCutting.Bus;
using Equinox.Infra.CrossCutting.Identity.User;
using Equinox.Infra.CrossCutting.IoC;
using Equinox.Infra.Data.Context;
using Equinox.Services.Api.Controllers;
using Equinox.UI.Web.Controllers;
using System.Reflection;

namespace Equinox.Tests.Architecture.Support;

public class TestsSupport
{
    public static IEnumerable<Assembly> GetAllProjectAssemblies()
    {
        IEnumerable<Assembly> assemblies = [typeof(HomeController).Assembly,
                                            typeof(AccountController).Assembly,
                                            typeof(CustomerAppService).Assembly,
                                            typeof(Customer).Assembly,
                                            typeof(StoredEvent).Assembly,
                                            typeof(EquinoxContext).Assembly,
                                            typeof(InMemoryBus).Assembly,
                                            typeof(AspNetUser).Assembly,
                                            typeof(NativeInjectorBootStrapper).Assembly];

        return assemblies;
    }
}
