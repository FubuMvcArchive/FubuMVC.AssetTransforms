using System.Linq;
using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Files;
using FubuMVC.StructureMap;
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
        public void meepmeep()
        {
            var compiler = new CoffeeScriptCompiler(new InstanceProvider<IJavaScriptRuntime>(() => new IEJavaScriptRuntime()));
            Assert.Pass(compiler.Compile("smoke = (x) -> x * x"));
        }
    }

    [TestFixture]
    public class CoffeeScriptCompilerIntegratedTester
    {
        [Test]
        public void compiles_the_script()
        {
            var compiler = FubuApplication
                .For<TestCoffeeScriptRegistry>()
                .StructureMapObjectFactory()
                .Bootstrap()
                .Facility
                .Get<ICoffeeCompiler>();

            Assert.Pass(compiler.Compile("smoke = (x) -> x * x"));
        }

        public class TestCoffeeScriptRegistry : FubuRegistry
        {
            public TestCoffeeScriptRegistry()
            {
                Import<CoffeeExtension>();
            }
        }
    }
}