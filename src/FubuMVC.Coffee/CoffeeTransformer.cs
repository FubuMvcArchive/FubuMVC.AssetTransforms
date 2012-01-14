using System.Collections.Generic;
using FubuMVC.Coffee.Compilers;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;

namespace FubuMVC.Coffee
{
    public class CoffeeTransformer : ITransformer
    {
        private readonly ICoffeeCompiler _coffeeCompiler;
        public CoffeeTransformer(ICoffeeCompiler coffeeCompiler)
        {
            _coffeeCompiler = coffeeCompiler;
        }

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return _coffeeCompiler.Compile(contents);
        }
    }
}