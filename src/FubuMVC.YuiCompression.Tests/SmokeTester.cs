using System.Diagnostics;
using System.IO;
using FubuMVC.Core.Assets;
using FubuMVC.Core.Assets.Files;
using FubuMVC.TestingHarness;
using NUnit.Framework;
using FubuTestingSupport;

namespace FubuMVC.YuiCompression.Tests
{
    [TestFixture]
    public class SmokeTester : FubuRegistryHarness
    {
        [Test]
        public void gets_compressed_javascript()
        {
            long original = new FileInfo(Path.Combine("..", "..", "content", "scripts", "slick.core.js")).Length;

            var actual = endpoints.GetAsset(AssetFolder.scripts, "slick.core.js").ContentLength();


            bool isCompressed = actual < original;

            isCompressed.ShouldBeTrue();
        }

        [Test]
        public void css_gets_compressed()
        {
            long original = new FileInfo(Path.Combine("..", "..", "content", "styles", "slick.grid.css")).Length;

            var actual = endpoints.GetAsset(AssetFolder.scripts, "slick.grid.css").ContentLength();


            bool isCompressed = actual < original;

            isCompressed.ShouldBeTrue();
        }
    }
}