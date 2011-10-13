using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;

namespace FubuMVC.Sass
{
    public class SassExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            var sassPolicy = JavascriptTransformerPolicy<SassTransformer>
                .For(ActionType.Transformation, ".sass", ".scss");

            registry.Services(s =>
            {
                s.AddService<ITransformerPolicy>(sassPolicy);
            });
        }
    }
}
