﻿namespace FubuMVC.Less
{
	public interface IFileReader
	{
		byte[] GetBinaryFileContents(string fileName);

		string GetFileContents(string fileName);

		bool DoesFileExist(string fileName);
	}
}