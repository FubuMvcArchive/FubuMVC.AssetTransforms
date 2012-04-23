using System;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using dotless.Core;
using dotless.Core.Parser;

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

		[Test]
		public void should_throw_when_invalid_source() {
			var engine = MockFor<LessEngine>();
			engine.Parser = new Parser();
			engine.Logger = new ExceptionLogger();
			Services.Inject<ILessEngine>(engine);
			Assert.Throws<ParserException>(() => ClassUnderTest.Compile("bomb()"));
		}
    }
}