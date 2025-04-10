using System.Text;
using Xunit.Abstractions;

namespace Equinox.Tests.Architecture.Support;

public class TestOutputHelperTextWriter(ITestOutputHelper output) : TextWriter
{
    private readonly ITestOutputHelper _output = output;

    public override void WriteLine(string? value)
    {
        _output.WriteLine(value ?? string.Empty);
    }

    public override Encoding Encoding => Encoding.UTF8;
}
