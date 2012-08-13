using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;
using Yahoo.Yui.Compressor;

namespace FubuMVC.YuiCompression
{
    public class YuiJavascriptCompressor : ITransformer
    {
        private readonly IJavaScriptCompressor _compressor;

        public YuiJavascriptCompressor(IJavaScriptCompressor compressor)
        {
            _compressor = compressor;
        }

        public string Transform(string contents, IEnumerable<AssetFile> files)
        {
            return _compressor.Compress(contents);
        }
    }
}