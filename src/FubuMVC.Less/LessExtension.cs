using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using dotless.Core;

namespace FubuMVC.Less
{
    public class LessExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            var lessPolicy = JavascriptTransformerPolicy<LessTransformer>
                .For(ActionType.Transformation, ".less");

            registry.Services(s =>
            {
                s.SetServiceIfNone<ILessEngine, LessEngine>();
                s.AddService<ITransformerPolicy>(lessPolicy);
            });
        }
    }
}
