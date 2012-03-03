using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;
using SassAndCoffee.Core;
using SassAndCoffee.JavaScript;
using SassAndCoffee.JavaScript.CoffeeScript;

namespace FubuMVC.Coffee
{
    // We're shooting for the drop-in bottle approach here
    public class CoffeeExtension : IFubuRegistryExtension
    {
        public const string COFFEE_EXTENSION = ".coffee";
        /* DSL for basic options: bare, globals and what impl of ICoffeeCompiler to use */

        public void Configure(FubuRegistry registry)
        {
            registry.Services(registerDefaultServices);
            MimeType.Javascript.AddExtension(COFFEE_EXTENSION);
        }

        private static void registerDefaultServices(IServiceRegistry s)
        {
            s.SetServiceIfNone<ICoffeeCompiler>(buildCompiler());
            s.AddService<ITransformerPolicy, CoffeeTransformerPolicy>();
        }

        private static ICoffeeCompiler buildCompiler()
        {
            return new SassCoffeeCompiler(new CoffeeScriptCompiler(new InstanceProvider<IJavaScriptRuntime>(() => new IEJavaScriptRuntime())));
        }
    }
}