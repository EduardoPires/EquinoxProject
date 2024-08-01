using Equinox.Application.Services;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Models;
using Equinox.Infra.CrossCutting.Bus;
using Equinox.Infra.CrossCutting.Identity.User;
using Equinox.Infra.CrossCutting.IoC;
using Equinox.Infra.Data.Context;
using Equinox.Services.Api.Controllers;
using Equinox.UI.Web.Controllers;
using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using System.Reflection;

namespace Equinox.Tests.Architecture;

public class WebApplicationTests
{    
    [Fact(DisplayName = "Web Application Should Not Have Data Dependencies")]
    [Trait("", "Web Application")]
    public void Application_ShouldNotHave_DataAccessDependencies()
    {
        // Arrange
        var appWeb = Types.InAssembly(typeof(HomeController).Assembly)
                          .That().DoNotResideInNamespace("Equinox.UI.Web.Configurations");

        // Act
        var result = appWeb
                        .ShouldNot()
                        .HaveDependencyOnAny
                            ("Equinox.Infra.Data")
                        .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} dependencie(s)");
    }
}
