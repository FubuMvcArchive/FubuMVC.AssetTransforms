using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;

namespace FubuMVC.Less
{
    public class LessTransformer : ITransformer
    {
        private readonly ILessCompiler _compiler;
        public LessTransformer(ILessCompiler compiler)
        {
            _compiler = compiler;
        }

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return _compiler.Compile(contents);
        }
    }
}