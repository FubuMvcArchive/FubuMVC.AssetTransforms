using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Sass.Tests
{
    [TestFixture]
    public class DefaultSassCompilerTester : InteractionContext<DefaultSassCompiler>
    {
        protected override void beforeEach()
        {
            Services.Inject<SassAndCoffee.Ruby.Sass.ISassCompiler>(new SassAndCoffee.Ruby.Sass.SassCompiler());
        }

        [Test]
        public void should_compile()
        {
            const string expected = "body {\n  color: blue; }\n";
            const string contents = "@mixin mine { color: blue } body { @include mine }";

            ClassUnderTest.Compile(contents).ShouldEqual(expected);
        }
    }
}