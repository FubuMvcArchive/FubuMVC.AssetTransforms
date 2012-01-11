using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;

namespace FubuMVC.Minifier
{
    public class MinifierTransformer : ITransformer
    {
        private readonly IMinifier _minifier;
        public MinifierTransformer(IMinifier minifier)
        {
            _minifier = minifier;
        }

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return _minifier.Minify(contents);
        }
    }
}