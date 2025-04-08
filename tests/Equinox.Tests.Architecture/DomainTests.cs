using Equinox.Domain.Core.Events;
using Equinox.Domain.Models;
using NetArchTest.Rules;

namespace Equinox.Tests.Architecture;

public class DomainTests
{
    [Fact(DisplayName = "Domain Should Not Have Any Dependencies")]
    [Trait("", "Domain")]
    public void Domain_ShouldNotHave_ProjectDependencies()
    {
        // Arrange
        var domain = Types.InAssembly(typeof(Customer).Assembly);

        // Act
        var result = domain
                        .ShouldNot()
                        .HaveDependencyOnAny
                            ("Equinox.UI.Web",
                             "Equinox.Services.Api",
                             "Equinox.Application",
                             "Equinox.Infra.Data",
                             "Equinox.Domain.Core",
                             "Equinox.Infra.CrossCutting.Bus",
                             "Equinox.Infra.CrossCutting.Identity",
                             "Equinox.Infra.CrossCutting.IoC")
                        .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} dependencie(s)");
    }

    [Fact(DisplayName = "Domain Namespace Should Have A Pattern")]
    [Trait("", "Domain")]
    public void DomainElements_MustReside_InSameNameSpace()
    {
        // Arrange
        var domain = Types.InAssembly(typeof(Customer).Assembly);

        // Act
        var result = domain
                        .Should()
                        .ResideInNamespaceStartingWith("Equinox.Domain")
                        .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} type(s)");
    }

    [Fact(DisplayName = "Domain Core Should Not Have Any Dependencies")]
    [Trait("", "Domain")]
    public void DomainCore_ShouldNotHave_ProjectDependencies()
    {
        // Arrange
        var domainCore = Types.InAssembly(typeof(StoredEvent).Assembly);

        // Act
        var result = domainCore
                        .ShouldNot()
                        .HaveDependencyOnAny
                            ("Equinox.UI.Web",
                             "Equinox.Services.Api",
                             "Equinox.Application",
                             "Equinox.Infra.Data",
                             "Equinox.Domain",
                             "Equinox.Infra.CrossCutting.Bus",
                             "Equinox.Infra.CrossCutting.Identity",
                             "Equinox.Infra.CrossCutting.IoC")
                        .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} dependencie(s)");
    }
}
