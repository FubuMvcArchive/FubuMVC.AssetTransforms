using SassAndCoffee.JavaScript.CoffeeScript;

namespace FubuMVC.Coffee.Compilers
{
    public class SassCoffeeCompiler : ICoffeeCompiler
    {
        private readonly CoffeeScriptCompiler _coffeeScriptCompiler;

        public SassCoffeeCompiler(CoffeeScriptCompiler coffeeScriptCompiler)
        {
            _coffeeScriptCompiler = coffeeScriptCompiler;
        }

        public string Compile(string code)
        {
            return _coffeeScriptCompiler.Compile(code);
        }
    }
}