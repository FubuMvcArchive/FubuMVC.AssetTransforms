using System.Web;
using FubuMVC.Core.Assets.Files;
using dotless.Core.Input;
using FubuCore;

namespace FubuMVC.Less {
	public class AssetPathResolver : IPathResolver 
	{
		private IAssetFileGraph _assetPipeline;
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