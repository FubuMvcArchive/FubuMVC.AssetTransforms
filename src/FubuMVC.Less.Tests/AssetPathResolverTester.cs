using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FubuMVC.Core.Assets.Files;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Less.Tests {
	[TestFixture]
	public class AssetPathResolverTester : InteractionContext<AssetPathResolver> 
	{
		[Test]
		public void should_resolve_existing_asset() 
		{
			const string path = @"C:\full\path";
			const string name = "imported";
			MockFor<IAssetPipeline>()
				.Stub(pipeline => pipeline.Find(name))
				.Return(new AssetFile(name) {FullPath = path});

			ClassUnderTest.GetFullPath(name).ShouldEqual(path);
		}
	}
}
