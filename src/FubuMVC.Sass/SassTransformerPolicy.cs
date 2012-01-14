using FubuMVC.Core.Assets.Content;

namespace FubuMVC.Sass
{
    public class SassTransformerPolicy : CssTransformerPolicy<SassTransformer>
    {
        public SassTransformerPolicy() : base(ActionType.BatchedTransformation, ".sass", ".scss") {}
    }
}