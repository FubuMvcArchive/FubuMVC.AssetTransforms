using System.IO;

namespace FubuMVC.Less
{
	public class DefaultFileReader : IFileReader
	{
		private readonly IPathResolver _pathResolver;

		public DefaultFileReader(IPathResolver pathResolver)
		{
			_pathResolver = pathResolver;
		}

		public byte[] GetBinaryFileContents(string fileName)
		{
			fileName = _pathResolver.GetFullPath(fileName);

			return File.ReadAllBytes(fileName);
		}

		public string GetFileContents(string fileName)
		{
			fileName = _pathResolver.GetFullPath(fileName);

			return File.ReadAllText(fileName);
		}

		public bool DoesFileExist(string fileName)
		{
			fileName = _pathResolver.GetFullPath(fileName);

			return File.Exists(fileName);
		}
	}
}