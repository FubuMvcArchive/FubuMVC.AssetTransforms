using CoffeeSharp;
using FubuTestingSupport;
using NUnit.Framework;
using SassAndCoffee.Core;
using SassAndCoffee.JavaScript;
using SassAndCoffee.JavaScript.CoffeeScript;

namespace FubuMVC.Coffee.Tests
{
    public class CoffeeTransformerTester : InteractionContext<CoffeeTransformer>
    {
        [Test]
        [Ignore]
        public void turtle()
        {
            var cse = new CoffeeScriptEngine();
            Assert.Pass(cse.Compile("smoke = (x) -> x * x"));
        }

        [Test]
        public void meepmeep()
        {
            var compiler = new CoffeeScriptCompiler(new InstanceProvider<IJavaScriptRuntime>(() => new IEJavaScriptRuntime()));
            Assert.Pass(compiler.Compile("smoke = (x) -> x * x"));
        }
    }
}
