using dotless.Core;
using dotless.Core.Loggers;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Less.Tests
{
    [TestFixture]
    public class DefaultServicesTester : InteractionContext<LessExtension>
    {
        private ServiceGraph _services;

        protected override void beforeEach()
        {
            var registry = new FubuRegistry();
            ClassUnderTest.As<IFubuRegistryExtension>().Configure(registry);
            _services = BehaviorGraph.BuildFrom(registry).Services;
        }

        [Test]
        public void less_engine()
        {
            _services.DefaultServiceFor<ILessEngine>()
				.ShouldNotBeNull()
				.Type.ShouldEqual(typeof(DefaultEngine));
        }

		[Test]
		public void engine_should_use_exception_logger() 
		{
			_services.DefaultServiceFor<ILogger>()
				.ShouldNotBeNull()
				.Type.ShouldEqual(typeof(ExceptionLogger));
		}

        [Test]
        public void less_compiler()
        {
            _services.DefaultServiceFor<ILessCompiler>()
				.ShouldNotBeNull()
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

	    [Test]
	    public void default_filereader()
	    {
		    _services.DefaultServiceFor<IFileReader>().ShouldNotBeNull()
			    .Type.ShouldEqual(typeof (DefaultFileReader));
	    }

	    [Test]
	    public void less_filereader_shim()
	    {
		    _services.DefaultServiceFor<dotless.Core.Input.IFileReader>().ShouldNotBeNull()
			    .Type.ShouldEqual(typeof (DotLessFileReaderShim));
	    }
    }
}