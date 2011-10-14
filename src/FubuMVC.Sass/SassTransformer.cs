using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;

namespace FubuMVC.Sass
{
    public class SassTransformer : ITransformer
    {
        private readonly ISassCompiler _sassCompiler;
        public SassTransformer(ISassCompiler sassCompiler)
        {
            _sassCompiler = sassCompiler;
        }

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return _sassCompiler.Compile(contents);
        }
    }
}