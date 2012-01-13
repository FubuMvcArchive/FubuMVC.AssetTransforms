using System.Linq;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Less.Tests
{
    public class LessTransformerTester : InteractionContext<LessTransformer>
    {
        [Test]
        public void should_use_the_provided_compiler()
        {
            ClassUnderTest.Transform(".a{}", Enumerable.Empty<AssetFile>());
            MockFor<ILessCompiler>().AssertWasCalled(x => x.Compile(".a{}"));
        }
    }
}
