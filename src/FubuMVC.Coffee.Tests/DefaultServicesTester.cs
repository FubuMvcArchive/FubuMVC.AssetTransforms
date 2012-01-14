using FubuCore;
using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Coffee.Tests
{
    [TestFixture]
    public class DefaultServicesTester : InteractionContext<CoffeeExtension>
    {
        private IServiceRegistry _services;

        protected override void beforeEach()
        {
            var registry = new FubuRegistry();
            ClassUnderTest.As<IFubuRegistryExtension>().Configure(registry);
            _services = registry.BuildLightGraph().Services;
        }

        [Test]
        public void coffee_compiler()
        {
            _services.DefaultServiceFor<ICoffeeCompiler>().ShouldNotBeNull()
                .Type.ShouldEqual(typeof(CoffeeSharpCompiler));
        }

        [Test]
        public void coffee_transformer_policy()
        {
            _services.ServicesFor<ITransformerPolicy>()
                .ShouldContain(x => x.Type.CanBeCastTo<CoffeeTransformerPolicy>());
        }
    }
}