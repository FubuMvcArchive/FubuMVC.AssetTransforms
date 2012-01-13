using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using dotless.Core;

namespace FubuMVC.Less
{
    public class LessExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            var lessPolicy = 
                new CssTransformerPolicy<LessTransformer>(ActionType.BatchedTransformation, ".less");

            registry.Services(s =>
            {
                s.SetServiceIfNone<ILessEngine>(new LessEngine());
                s.SetServiceIfNone<ILessCompiler, LessCompiler>();
                s.AddService<ITransformerPolicy>(lessPolicy);
            });
        }
    }
}
