using Equinox.Tests.Architecture.Support;
using NetArchTest.Rules;

namespace Equinox.Tests.Architecture;

public class GeneralPatternTests
{    
    [Fact(DisplayName = "Base Classes Must Be Abstract")]
    [Trait("", "General")]
    public void BaseClasses_MustBe_Abstract()
    {
        // Arrange
        var assemblies = TestsSupport.GetAllProjectAssemblies();

        var baseClasses = Types.InAssemblies(assemblies)                               
                               .That().AreClasses()
                               .And().HaveNameStartingWith("Base");

        // Act
        var result = baseClasses.Should()
                                .BeAbstract()
                                .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} objects(s)");
    }

    [Fact(DisplayName = "Interfaces Must Starts With I")]
    [Trait("", "General")]
    public void Interfaces_MustStarts_WithI()
    {
        // Arrange
        var assemblies = TestsSupport.GetAllProjectAssemblies();

        var interfaces = Types.InAssemblies(assemblies)
                               .That().AreInterfaces();

        // Act
        var result = interfaces.Should()
                               .HaveNameStartingWith("I")
                               .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} objects(s)");
    }
}
