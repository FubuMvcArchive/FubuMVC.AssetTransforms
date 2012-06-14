using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Sass.Tests
{
    [TestFixture]
    public class DefaultServicesTester : InteractionContext<SassExtension>
    {
        private ServiceGraph _services;

        protected override void beforeEach()
        {
            var registry = new FubuRegistry();
            ClassUnderTest.As<IFubuRegistryExtension>().Configure(registry);
            _services = BehaviorGraph.BuildFrom(registry).Services;
        }

        [Test]
        public void sass_compiler()
        {
            _services.DefaultServiceFor<ISassCompiler>().ShouldNotBeNull()
                .Type.ShouldEqual(typeof(DefaultSassCompiler));
        }

        [Test]
        public void sass_compiler_dependencies()
        {
            _services.DefaultServiceFor<SassAndCoffee.Ruby.Sass.ISassCompiler>()
                .Type.ShouldEqual(typeof(SassAndCoffee.Ruby.Sass.SassCompiler));
        }

        [Test]
        public void sass_transformer_policy()
        {
            _services.ServicesFor<ITransformerPolicy>()
                .ShouldContain(x => x.Type.CanBeCastTo<SassTransformerPolicy>());
        }
    }
}