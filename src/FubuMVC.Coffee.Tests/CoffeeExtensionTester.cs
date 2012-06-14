using FubuCore;
using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Coffee.Tests
{
    [TestFixture]
    public class CoffeeExtensionTester : InteractionContext<CoffeeExtension>
    {
        private ServiceGraph _services;

        protected override void beforeEach()
        {
            var registry = new FubuRegistry();
            ClassUnderTest.As<IFubuRegistryExtension>().Configure(registry);
            _services = BehaviorGraph.BuildFrom(registry).Services;
        }

        [Test]
        public void registers_coffee_mime_type()
        {
            MimeType.Javascript.HasExtension(CoffeeExtension.COFFEE_EXTENSION).ShouldBeTrue();
        }

        [Test]
        public void coffee_compiler()
        {
            _services
                .DefaultServiceFor<ICoffeeCompiler>()
                .ShouldNotBeNull();
        }

        [Test]
        public void coffee_transformer_policy()
        {
            _services.ServicesFor<ITransformerPolicy>()
                .ShouldContain(x => x.Type.CanBeCastTo<CoffeeTransformerPolicy>());
        }
    }
}