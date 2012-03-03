using FubuMVC.Core.Assets.Content;

namespace FubuMVC.Less
{
    public class LessTransformerPolicy : CssTransformerPolicy<LessTransformer>
    {
        public LessTransformerPolicy() : base(ActionType.BatchedTransformation, LessExtension.LESS_EXTENSION) { }
    }
}