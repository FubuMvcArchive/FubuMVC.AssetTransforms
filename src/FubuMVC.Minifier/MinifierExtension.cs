using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Runtime;

namespace FubuMVC.Minifier
{
    public class MinifierExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            var minifierPolicy = JavascriptTransformerPolicy<MinifierTransformer>
                .For(ActionType.Transformation, MimeType.Javascript.DefaultExtension());

            minifierPolicy.AddExclusionCriteria(file => file.Name.Contains(".min."));

            registry.Services(s =>
            {
                s.AddService<ITransformerPolicy>(minifierPolicy);
                s.SetServiceIfNone<IMinifier, UglifyMinifier>();
            });
        }
    }
}
