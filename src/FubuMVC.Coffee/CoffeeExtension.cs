using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Runtime;

namespace FubuMVC.Coffee
{
    public class CoffeeExtension : IFubuRegistryExtension
    {
        private readonly string[] _extensions = new[] { ".coffee" };

        /* DSL for basic options: bare, globals and what impl of ICoffeeCompiler to use */

        // Temporary

        public void Configure(FubuRegistry registry)
        {

            _extensions.Each(MimeType.Javascript.AddExtension);

            var coffeePolicy = JavascriptTransformerPolicy<CoffeeTransformer>
                .For(ActionType.BatchedTransformation, _extensions);
            
            registry.Services(s =>
            {
                s.SetServiceIfNone<ICoffeeCompiler, CoffeeSharpEngine>();
                s.AddService<ITransformerPolicy>(coffeePolicy);
            });
        }
    }
}
