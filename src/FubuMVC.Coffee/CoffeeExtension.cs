using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;

namespace FubuMVC.Coffee
{
    // We're shooting for the drop-in bottle approach here
    public class CoffeeExtension : IFubuRegistryExtension
    {
        public const string COFFEE_EXTENSION = ".coffee";
        /* DSL for basic options: bare, globals and what impl of ICoffeeCompiler to use */

        public void Configure(FubuRegistry registry)
        {
            registry.Services<CoffeeServices>();
            MimeType.Javascript.AddExtension(COFFEE_EXTENSION);
        }
    }

    public class CoffeeServices : ServiceRegistry
    {
        public CoffeeServices()
        {
            AddService<ITransformerPolicy, CoffeeTransformerPolicy>();
            SetServiceIfNone<ICoffeeCompiler, CoffeeCompiler>();
        }
    }
}