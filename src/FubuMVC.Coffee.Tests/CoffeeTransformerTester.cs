using System.Linq;
using CoffeeSharp;
using FubuMVC.Coffee.Compilers;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using SassAndCoffee.Core;
using SassAndCoffee.JavaScript;
using SassAndCoffee.JavaScript.CoffeeScript;

namespace FubuMVC.Coffee.Tests
{
    [TestFixture]
    public class CoffeeTransformerTester : InteractionContext<CoffeeTransformer>
    {
        [Test]
        public void should_use_the_provided_compiler()
        {
            const string code = "smoke = (x) -> x * x";
            ClassUnderTest.Transform(code, Enumerable.Empty<AssetFile>());
            MockFor<ICoffeeCompiler>().AssertWasCalled(x => x.Compile(code));
        }

        [Test]
        [Ignore]
        public void turtle()
        {
            var cse = new CoffeeScriptEngine();
            Assert.Pass(cse.Compile("smoke = (x) -> x * x"));
        }

        [Test]
        [Ignore]
        public void meepmeep()
        {
            var compiler = new CoffeeScriptCompiler(new InstanceProvider<IJavaScriptRuntime>(() => new IEJavaScriptRuntime()));
            Assert.Pass(compiler.Compile("smoke = (x) -> x * x"));
        }
    }
}