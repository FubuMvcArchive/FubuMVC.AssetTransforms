using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Coffee.Tests
{
    [TestFixture]
    public class CoffeeTransformerPolicyTester : InteractionContext<CoffeeTransformerPolicy>
    {
        [Test]
        public void applies_to_positive_based_on_mimetype()
        {
            ClassUnderTest.AppliesTo(new AssetFile("irish.coffee")).ShouldBeTrue();
        }

        [Test]
        public void applies_to_negative_on_others()
        {
            ClassUnderTest.AppliesTo(new AssetFile("this.js")).ShouldBeFalse();
        }

        [Test]
        public void should_be_batched_transformation()
        {
            ClassUnderTest.ActionType.ShouldEqual(ActionType.BatchedTransformation);
        }
    }
}