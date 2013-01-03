using SassAndCoffee.JavaScript.CoffeeScript;

namespace FubuMVC.Coffee.Compilers
{
    public class SassCoffeeCompiler : ICoffeeCompiler
    {
        private readonly CoffeeScriptCompiler _coffeeScriptCompiler;
        private static readonly object Lock = new object();

        public SassCoffeeCompiler(CoffeeScriptCompiler coffeeScriptCompiler)
        {
            _coffeeScriptCompiler = coffeeScriptCompiler;
        }

        public string Compile(string code)
        {
            lock (Lock)
            {
                return _coffeeScriptCompiler.Compile(code);
            }
        }
    }
}