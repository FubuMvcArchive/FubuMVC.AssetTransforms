using System;
using System.IO;
using FubuCore;

namespace FubuMVC.Less.Tests
{
	public class FileScenario
	{
		private readonly string _directory;
		private readonly IFileSystem _fileSystem;

		public FileScenario(string directory, IFileSystem fileSystem)
		{
			_directory = directory;
			_fileSystem = fileSystem;
		}

		public static FileScenario Create(Action<FileScenarioDefinition> configure)
		{
			var directory = Path.GetTempPath().AppendRandomPath();
			var fileSystem = new FileSystem();
			fileSystem.CreateDirectory(directory);

			var definition = new FileScenarioDefinition(directory);
			configure(definition);

			return new FileScenario(directory, fileSystem);
		}

		public string Directory
		{
			get { return _directory; }
		}

		public void Cleanup()
		{
			_fileSystem.DeleteDirectory(_directory);
		}
	}

	public class FileScenarioDefinition
	{
		private readonly string _directory;

		public FileScenarioDefinition(string directory)
		{
			_directory = directory;
		}

		public string Directory { get { return _directory; } }

		public void Asset(string name, string fileContents)
		{
			var path = Path.Combine(_directory, name);
			File.WriteAllText(path, fileContents);
		}
	}

	public static class FileSystemExtensions
	{
		public static string AppendRandomPath(this string path)
		{
			return path.AppendPath((Guid.NewGuid().ToString().Replace("-", String.Empty)));
		}
	}
}
