using Cassette;
using Cassette.Scripts;

namespace FubuMVC.Coffee.Compilers
{
    public interface ICoffeeCompiler
    {
        string Compile(string code);
    }

    public class CoffeeCompiler : ICoffeeCompiler
    {
        public string Compile(string code)
        {
            return new JurassicCoffeeScriptCompiler().Compile(code, new CompileContext
            {
                SourceFilePath = "unknown"
            }).Output;
        }
    }
}