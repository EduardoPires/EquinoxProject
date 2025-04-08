using System.Text;
using Xunit.Abstractions;

namespace Equinox.Tests.Architecture.Support;

public class TestOutputHelperTextWriter : TextWriter
{
    private readonly ITestOutputHelper _output;

    public TestOutputHelperTextWriter(ITestOutputHelper output)
    {
        _output = output;
    }

    public override void WriteLine(string value)
    {
        _output.WriteLine(value);
    }

    public override Encoding Encoding => Encoding.UTF8;
}
