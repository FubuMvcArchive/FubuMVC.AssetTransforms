using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuTestingSupport;
using NUnit.Framework;
using dotless.Core;

namespace FubuMVC.Less.Tests
{
    public class DefaultServicesTester : InteractionContext<LessExtension>
    {
        private IServiceRegistry _services;

        protected override void beforeEach()
        {
            var registry = new FubuRegistry();
            ClassUnderTest.As<IFubuRegistryExtension>().Configure(registry);
            _services = registry.BuildLightGraph().Services;
        }

        [Test]
        public void less_engine()
        {
            _services.DefaultServiceFor<ILessEngine>()
                .Value.ShouldBeOfType<LessEngine>();
        }

        [Test]
        public void less_compiler()
        {
            _services.DefaultServiceFor<ILessCompiler>().ShouldNotBeNull()
                .Type.ShouldEqual(typeof(LessCompiler));
        }

        [Test]
        public void less_transformer_policy()
        {
            _services.ServicesFor<ITransformerPolicy>()
                .ShouldContain(x => x.Type.CanBeCastTo<LessTransformerPolicy>());
        }
    }
}