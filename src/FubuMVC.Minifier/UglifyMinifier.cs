using SassAndCoffee.Core;
using SassAndCoffee.JavaScript;
using SassAndCoffee.JavaScript.Uglify;

namespace FubuMVC.Minifier
{
    public class UglifyMinifier : IMinifier
    {
        private readonly UglifyCompiler _compiler;

        public UglifyMinifier()
        {
            var instanceProvider = new InstanceProvider<IJavaScriptRuntime>(() => new IEJavaScriptRuntime());
            _compiler = new UglifyCompiler(instanceProvider);
        }

        public string Minify(string code)
        {
            return _compiler.Compile(code);
        }
    }
}