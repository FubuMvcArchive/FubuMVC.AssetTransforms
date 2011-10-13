using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;

namespace FubuMVC.Coffee
{
    public class CoffeeExtension : IFubuRegistryExtension
    {
        /* DSL for basic options: bare, globals and what impl of ICoffeeCompiler to use */

        // Temporary

        public void Configure(FubuRegistry registry)
        {
            var coffeePolicy = JavascriptTransformerPolicy<CoffeeTransformer>
                .For(ActionType.Transformation, ".coffee");
            
            registry.Services(s =>
            {
                s.SetServiceIfNone<ICoffeeCompiler, CoffeeSharpEngine>();
                s.AddService<ITransformerPolicy>(coffeePolicy);
            });
        }
    }
}
