using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Less.Tests
{
    [TestFixture]
    public class LessTransformerPolicyTester : InteractionContext<LessTransformerPolicy>
    {
        [Test]
        public void applies_to_positive_based_on_mimetype()
        {
            ClassUnderTest.AppliesTo(new AssetFile("rest.less")).ShouldBeTrue();
        }

        [Test]
        public void applies_to_negative_on_css()
        {
            ClassUnderTest.AppliesTo(new AssetFile("base.css")).ShouldBeFalse();
        }

        [Test]
        public void should_be_batched_transformation()
        {
            ClassUnderTest.ActionType.ShouldEqual(ActionType.BatchedTransformation);
        }
    }
}