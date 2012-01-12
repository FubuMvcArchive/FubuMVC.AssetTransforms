using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Sass.Tests
{
    public class SassTransformerTester : InteractionContext<SassTransformer>
    {
        [Test]
        public void should_compile()
        {
            Services.Inject(typeof(ISassCompiler), new DefaultSassCompiler(new SassAndCoffee.Ruby.Sass.SassCompiler()));

            var actual = ClassUnderTest.Transform("@mixin mine { color: blue } body { @include mine }", null);

            const string expected = "body {\n  color: blue; }\n";
            actual.ShouldEqual(expected);
        }
    }
}
