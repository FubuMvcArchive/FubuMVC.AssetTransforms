using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Sass.Tests
{
    [TestFixture]
    public class SassTransformerTester : InteractionContext<SassTransformer>
    {
        protected override void beforeEach()
        {
            var sassCompiler = new SassAndCoffee.Ruby.Sass.SassCompiler();
            Services.Inject(typeof(ISassCompiler), new DefaultSassCompiler(sassCompiler));
        }

        [Test]
        public void should_compile()
        {
            const string expected = "body {\n  color: blue; }\n";
            const string contents = "@mixin mine { color: blue } body { @include mine }";

            ClassUnderTest.Transform(contents, null)
                .ShouldEqual(expected);
        }
    }
}
