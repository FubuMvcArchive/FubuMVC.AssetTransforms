using System.Linq;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Sass.Tests
{
    [TestFixture]
    public class SassTransformerTester : InteractionContext<SassTransformer>
    {
        [Test]
        public void should_use_the_provided_compiler()
        {
            ClassUnderTest.Transform(".sass{}", Enumerable.Empty<AssetFile>());
            MockFor<ISassCompiler>().AssertWasCalled(x => x.Compile(".sass{}"));
        }
    }
}