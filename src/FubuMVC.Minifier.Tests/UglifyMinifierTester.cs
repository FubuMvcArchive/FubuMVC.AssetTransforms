using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Minifier.Tests
{
    [TestFixture]
    public class UglifyMinifierTester : InteractionContext<UglifyMinifier>
    {
        [Test]
        public void smoke()
        {
            const string code = "var roundKickingBananas = 1337;";

            ClassUnderTest.Minify(code)
                .ShouldNotBeNull()
                .Length.ShouldBeLessThan(code.Length);
        }
    }
}
