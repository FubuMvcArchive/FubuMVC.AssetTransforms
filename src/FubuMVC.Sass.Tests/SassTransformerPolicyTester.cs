using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Sass.Tests
{
    [TestFixture]
    public class SassTransformerPolicyTester : InteractionContext<SassTransformerPolicy>
    {
        [Test]
        public void applies_to_positive_based_on_mimetype_1()
        {
            ClassUnderTest.AppliesTo(new AssetFile("a.sass")).ShouldBeTrue();
        }

        [Test]
        public void applies_to_positive_based_on_mimetype_2()
        {
            ClassUnderTest.AppliesTo(new AssetFile("b.scss")).ShouldBeTrue();
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