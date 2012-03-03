using FubuMVC.Core.Assets.Content;

namespace FubuMVC.Coffee
{
    public class CoffeeTransformerPolicy : JavascriptTransformerPolicy<CoffeeTransformer>
    {
        public CoffeeTransformerPolicy() : base(ActionType.BatchedTransformation, CoffeeExtension.COFFEE_EXTENSION) { }
    }
}