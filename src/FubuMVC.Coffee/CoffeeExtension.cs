using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;

namespace FubuMVC.Coffee
{
    public class CoffeeExtension : IFubuRegistryExtension
    {
        /* DSL for basic options: bare, globals and what impl of ICoffeeCompiler to use */

        public void Configure(FubuRegistry registry)
        {
            registry.Services(services);
        }

        private static void services(IServiceRegistry s)
        {
            s.SetServiceIfNone<ICoffeeCompiler, CoffeeSharpCompiler>();
            s.AddService<ITransformerPolicy, CoffeeTransformerPolicy>();
        }
    }
}