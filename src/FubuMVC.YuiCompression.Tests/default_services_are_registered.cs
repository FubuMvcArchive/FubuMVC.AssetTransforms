using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using NUnit.Framework;
using Yahoo.Yui.Compressor;
using FubuTestingSupport;
using System.Linq;

namespace FubuMVC.YuiCompression.Tests
{
    [TestFixture]
    public class default_services_are_registered
    {
        private ServiceGraph theServices;

        [SetUp]
        public void SetUp()
        {
            var registry = new FubuRegistry();
            registry.Import<YuiCompressionExtensions>();

            theServices = BehaviorGraph.BuildFrom(registry).Services;
        }

        [Test]
        public void javascript_compressor_is_registered()
        {
            theServices.DefaultServiceFor<IJavaScriptCompressor>()
                .Type.ShouldEqual(typeof (JavaScriptCompressor));
        }

        [Test]
        public void css_compressor_is_registered()
        {
            theServices.DefaultServiceFor<ICssCompressor>()
                .Type.ShouldEqual(typeof (CssCompressor));
        }

    }
}