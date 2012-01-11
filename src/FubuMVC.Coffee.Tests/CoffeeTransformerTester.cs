using CoffeeSharp;
using FubuTestingSupport;
using NUnit.Framework;
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
//            var compiler = new CoffeeScriptCompiler()
//            Assert.Pass(compiler.Compile("smoke = (x) -> x * x"));
        }
    }
}
