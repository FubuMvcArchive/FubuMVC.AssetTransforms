using System;
using FubuMVC.Coffee.Compilers;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.ObjectGraph;
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

        private static void registerDefaultServices(ServiceRegistry registry)
        {
            registerCompiler(registry);
            registry.AddService<ITransformerPolicy, CoffeeTransformerPolicy>();
        }

        private static void registerCompiler(ServiceRegistry registry)
        {
            var compilerDef = registry.SetServiceIfNone(typeof (ICoffeeCompiler), typeof (SassCoffeeCompiler));
            var innerCompilerDef = ObjectDef.ForType<CoffeeScriptCompiler>();
            
            var instanceProvider = ObjectDef.ForType<InstanceProvider<IJavaScriptRuntime>>();
            Func<IJavaScriptRuntime> runtimeFunc = () => new IEJavaScriptRuntime();
            instanceProvider.DependencyByValue(typeof(Func<IJavaScriptRuntime>), runtimeFunc);
            innerCompilerDef.Dependency(typeof(IInstanceProvider<IJavaScriptRuntime>), instanceProvider);
            compilerDef.Dependency(typeof(CoffeeScriptCompiler), innerCompilerDef);
        }
    }

}