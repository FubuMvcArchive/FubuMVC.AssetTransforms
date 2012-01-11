using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Runtime;
using dotless.Core;

namespace FubuMVC.Less
{
    public class LessExtension : IFubuRegistryExtension
    {
        private readonly string[] _extensions = new[] { ".less" };

        public void Configure(FubuRegistry registry)
        {
            _extensions.Each(MimeType.Css.AddExtension);
            var lessPolicy = new CssTransformerPolicy<LessTransformer>(ActionType.BatchedTransformation, _extensions);

            registry.Services(s =>
            {
                s.SetServiceIfNone<ILessEngine, LessEngine>();
                s.AddService<ITransformerPolicy>(lessPolicy);
            });
        }
    }
}
