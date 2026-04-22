using Soenneker.Tests.HostedUnit;


namespace Soenneker.Validators.Validator.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ValidatorTests : HostedUnitTest
{
    public ValidatorTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {
    }
}