using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FubuMVC.Core.Assets.Files;
using FubuMVC.Core.Runtime;
using FubuMVC.TestingHarness;
using NUnit.Framework;

namespace FubuMVC.Coffee.Tests
{
    [TestFixture]
    public class CoffeeSmokeTester: FubuRegistryHarness
    {
        [Test]
        public void transforms_coffee_to_javascript()
        {
            var response = endpoints.GetAsset(AssetFolder.scripts, "coffeeHello.coffee");
            response.ContentTypeShouldBe(MimeType.Javascript);
        }
    }
}
