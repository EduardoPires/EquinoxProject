using Mono.Cecil;
using NetArchTest.Rules;

namespace Equinox.Tests.Architecture.Support;

public class ShouldUseDependencyInjectionRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        if (!type.IsClass || !type.IsPublic)
        {
            return true; // Ignore non-public classes or non-classes
        }

        foreach (var method in type.Methods)
        {
            if (method.IsConstructor && method.HasParameters)
            {
                Console.WriteLine($"The class {type.Name} has a constructor with {method.Parameters.Count()} parameters");
                return true;
            }
        }

        // If we found no constructors with parameters, assume the class does not use DI
        return false;
    }
}
