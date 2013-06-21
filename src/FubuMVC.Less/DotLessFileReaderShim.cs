namespace FubuMVC.Less
{
	public class DotLessFileReaderShim : dotless.Core.Input.IFileReader
	{
		private readonly IFileReader _fileReader;

		public DotLessFileReaderShim(IFileReader fileReader)
		{
			_fileReader = fileReader;
		}

		public byte[] GetBinaryFileContents(string fileName)
		{
			return _fileReader.GetBinaryFileContents(fileName);
		}

		public string GetFileContents(string fileName)
		{
			return _fileReader.GetFileContents(fileName);
		}

		public bool DoesFileExist(string fileName)
		{
			return _fileReader.DoesFileExist(fileName);
		}
	}
}