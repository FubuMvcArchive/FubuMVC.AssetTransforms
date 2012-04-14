using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuTestingSupport;
using NUnit.Framework;
using dotless.Core;
using dotless.Core.Input;

namespace FubuMVC.Less.Tests
{
    [TestFixture]
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
            _services.DefaultServiceFor<ILessEngine>().ShouldNotBeNull()
				.Type.ShouldEqual(typeof(LessEngine));
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

		[Test]
		public void less_path_resolver() 
		{
			_services.DefaultServiceFor<IPathResolver>().ShouldNotBeNull()
				.Type.ShouldEqual(typeof(AssetPathResolver));
		}

    }
}