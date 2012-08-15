using System;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Runtime;
using Yahoo.Yui.Compressor;

namespace FubuMVC.YuiCompression
{
    public class YuiCompressionExtensions : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            var cssPolicy = new CssTransformerPolicy<YuiCssCompressor>(ActionType.Global);
            cssPolicy.AddExclusionCriteria(file => file.Name.Contains(".min."));

            var jsPolicy = JavascriptTransformerPolicy<YuiJavascriptCompressor>
                .For(ActionType.Global);

            jsPolicy.AddMatchingCriteria(file => file.MimeType == MimeType.Javascript);
            jsPolicy.AddExclusionCriteria(file => file.Name.Contains(".min."));

            registry.Services(x =>
            {
                x.SetServiceIfNone<IJavaScriptCompressor, JavaScriptCompressor>();
                x.SetServiceIfNone<ICssCompressor, CssCompressor>();

                x.AddService<ITransformerPolicy>(cssPolicy);
                x.AddService<ITransformerPolicy>(jsPolicy);
            });    
        }
    }
}