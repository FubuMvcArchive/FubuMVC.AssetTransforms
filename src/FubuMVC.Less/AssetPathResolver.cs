using FubuCore;
using FubuMVC.Core.Assets.Files;

namespace FubuMVC.Less {
	public class AssetPathResolver : IPathResolver 
	{
		private readonly IAssetFileGraph _assetPipeline;

		public AssetPathResolver(IAssetFileGraph assetPipeline)
		{
			_assetPipeline = assetPipeline;
		}

		public string GetFullPath(string path) 
		{
			if (CurrentFolder.IsNotEmpty()) path = string.Concat(CurrentFolder, "/", path);
			var assetFile = _assetPipeline.Find(path);
			if (assetFile == null)
				return null;
			return assetFile.FullPath;
		}

		public string CurrentFolder { get; set; }
	}
}