using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using dotless.Core;

namespace FubuMVC.Less.Tests
{
    [TestFixture]
    public class LessCompilerTester : InteractionContext<LessCompiler>
    {
        [Test]
        public void should_use_less_engine()
        {
            ClassUnderTest.Compile(".a{}");
            MockFor<ILessEngine>().AssertWasCalled(x => x.TransformToCss(".a{}", null));
        }
    }
}