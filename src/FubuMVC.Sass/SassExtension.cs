using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;

namespace FubuMVC.Sass
{
    public class SassExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Services(services);
        }

        private static void services(IServiceRegistry s)
        {
            s.SetServiceIfNone<ISassCompiler, DefaultSassCompiler>();
            s.SetServiceIfNone<SassAndCoffee.Ruby.Sass.ISassCompiler, SassAndCoffee.Ruby.Sass.SassCompiler>();
            s.AddService<ITransformerPolicy, SassTransformerPolicy>();            
        }
    }
}
