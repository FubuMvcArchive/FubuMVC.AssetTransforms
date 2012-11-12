using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;

namespace FubuMVC.Sass
{
    public class SassExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Services<SassServices>();
        }

    }

    public class SassServices : ServiceRegistry
    {
        public SassServices()
        {
            SetServiceIfNone<ISassCompiler, DefaultSassCompiler>();
            SetServiceIfNone<SassAndCoffee.Ruby.Sass.ISassCompiler, SassAndCoffee.Ruby.Sass.SassCompiler>();
            AddService<ITransformerPolicy, SassTransformerPolicy>();     
        }
    }
}
