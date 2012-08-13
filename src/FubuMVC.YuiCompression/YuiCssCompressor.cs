using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;
using Yahoo.Yui.Compressor;

namespace FubuMVC.YuiCompression
{
    public class YuiCssCompressor : ITransformer
    {
        private readonly ICssCompressor _compressor;

        public YuiCssCompressor(ICssCompressor compressor)
        {
            _compressor = compressor;
        }

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return _compressor.Compress(contents);
        }
    }
}