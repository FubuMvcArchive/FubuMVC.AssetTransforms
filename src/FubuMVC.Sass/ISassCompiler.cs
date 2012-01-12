using System.IO;

namespace FubuMVC.Sass
{
    public interface ISassCompiler
    {
        string Compile(string content);
    }

    public class DefaultSassCompiler : ISassCompiler
    {
        readonly SassAndCoffee.Ruby.Sass.ISassCompiler _compiler;

        public DefaultSassCompiler(SassAndCoffee.Ruby.Sass.ISassCompiler compiler)
        {
            _compiler = compiler;
        }

        public string Compile(string content)
        {
            var fileName = Path.GetTempFileName();
            File.WriteAllText(fileName, content);
            return _compiler.Compile(fileName, false, null);
        }
    }
}