using CoffeeSharp;

namespace FubuMVC.Coffee.Compilers
{
    public class CoffeeSharpCompiler : ICoffeeCompiler
    {
        private readonly CoffeeScriptEngine _engine;
        public CoffeeSharpCompiler(CoffeeScriptEngine engine)
        {
            _engine = engine;
        }

        public string Compile(string code)
        {
            return _engine.Compile(code);
        }
    }
}