using System.Collections.Generic;
using System.Linq;
using System.Text;
using FubuCore;

namespace FubuMVC.Less
{
	public class LessFileTransformerFileReader : IFileReader
	{
		private readonly IPathResolver _pathResolver;
		private readonly IEnumerable<IFileTransformer> _transformers;
		private readonly IFileSystem _fileSystem;

		public LessFileTransformerFileReader(
			IPathResolver pathResolver,
			IEnumerable<IFileTransformer> transformers,
			IFileSystem fileSystem)
		{
			_pathResolver = pathResolver;
			_transformers = transformers;
			_fileSystem = fileSystem;
		}

		public byte[] GetBinaryFileContents(string fileName)
		{
			fileName = _pathResolver.GetFullPath(fileName);

			return Encoding.UTF8.GetBytes(_fileSystem.ReadStringFromFile(fileName));
		}

		public string GetFileContents(string fileName)
		{
			var fullFilePath = _pathResolver.GetFullPath(fileName);

			var content = _fileSystem.ReadStringFromFile(fullFilePath);

			var result = _transformers
				.Where(transformer => transformer.CanTransform(fileName))
				.Aggregate(content, (current, transformer) => transformer.Transform(fileName, current));
			return result;
		}

		public bool DoesFileExist(string fileName)
		{
			fileName = _pathResolver.GetFullPath(fileName);

			return _fileSystem.FileExists(fileName);
		}
	}
}
