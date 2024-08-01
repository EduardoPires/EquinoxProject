using Equinox.Tests.Architecture.Support;
using NetArchTest.Rules;
using Xunit.Abstractions;

namespace Equinox.Tests.Architecture;

public class DataBaseTests
{
    private readonly ITestOutputHelper _output;

    public DataBaseTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new TestOutputHelperTextWriter(_output));
    }


    [Fact(DisplayName = "Repository Classes Must Have Constructor With Parameters")]
    [Trait("", "Database")]
    public void RepositoryClasses_MustHave_ConstructorWithParameters()
    {
        // Arrange
        var assemblies = TestsSupport.GetAllProjectAssemblies();

        var repositories = Types.InAssemblies(assemblies)
                                .That().AreClasses()
                                .And().HaveNameEndingWith("Repository");

        // Act
        var result = repositories
                        .Should()
                        .MeetCustomRule(new ShouldUseDependencyInjectionRule())
                        .GetResult();

        Assert.True(result.IsSuccessful, $"Failed in {result.FailingTypes?.Count} objects(s)");
    }
}
