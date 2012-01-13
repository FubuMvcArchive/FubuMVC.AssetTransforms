using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;

namespace FubuMVC.Sass
{
    public class SassExtension : IFubuRegistryExtension
    {
        private readonly string[] _extensions = new[] { ".sass", ".scss" };

        public void Configure(FubuRegistry registry)
        {
            var sassPolicy = 
                new CssTransformerPolicy<SassTransformer>(ActionType.BatchedTransformation, _extensions);

            registry.Services(s =>
            {
                s.SetServiceIfNone<ISassCompiler, DefaultSassCompiler>();
                s.SetServiceIfNone<SassAndCoffee.Ruby.Sass.ISassCompiler, SassAndCoffee.Ruby.Sass.SassCompiler>();
                s.AddService<ITransformerPolicy>(sassPolicy);
            });
        }
    }
}
