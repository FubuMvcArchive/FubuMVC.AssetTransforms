using CoffeeSharp;
using SassAndCoffee.JavaScript.CoffeeScript;

namespace FubuMVC.Coffee
{
    public class CoffeeSharpEngine : ICoffeeCompiler
    {
        private readonly CoffeeScriptEngine _engine;
        public CoffeeSharpEngine(CoffeeScriptEngine engine)
        {
            _engine = engine;
        }

        public string Compile(string code)
        {
            return _engine.Compile(code);
        }
    }

    public class SassCoffeeEngine : ICoffeeCompiler
    {
        private readonly CoffeeScriptCompiler _coffeeScriptCompiler;

        public SassCoffeeEngine(CoffeeScriptCompiler coffeeScriptCompiler)
        {
            _coffeeScriptCompiler = coffeeScriptCompiler;
        }

        public string Compile(string code)
        {
            return _coffeeScriptCompiler.Compile(code);
        }
    }
}