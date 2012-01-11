using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;

namespace FubuMVC.Minifier
{
    public class MinifierTransformer : ITransformer
    {
        public MinifierTransformer() {}

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return contents;
        }
    }
}