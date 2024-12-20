using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Validators.Validator.Tests;

[Collection("Collection")]
public class ValidatorTests : FixturedUnitTest
{
    public ValidatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {
    }
}