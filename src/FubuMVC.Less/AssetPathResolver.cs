using System.Web;
using FubuMVC.Core.Assets.Files;
using dotless.Core.Input;

namespace FubuMVC.Less {
	public class AssetPathResolver : IPathResolver 
	{
		private IAssetPipeline _assetPipeline;
		public AssetPathResolver(IAssetPipeline assetPipeline) 
		{
			_assetPipeline = assetPipeline;
		}

		public string GetFullPath(string path) 
		{
			var assetFile = _assetPipeline.Find(path);
			if (assetFile == null)
				return null;
			return assetFile.FullPath;
		}
	}
}