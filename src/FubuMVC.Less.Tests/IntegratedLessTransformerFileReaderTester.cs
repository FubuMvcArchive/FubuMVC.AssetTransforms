using System.Collections.Generic;
using System.IO;
using System.Text;
using FubuCore;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Less.Tests
{
	[TestFixture]
	public class IntegratedLessTransformerFileReaderTester : FileScenarioContext
	{
		private const string BaseFileName = "base.less";
		private const string BaseContents = "@import \"variables.less\"";
		private const string SecondContents = "@brandAccent: #fff;";
		private LessFileTransformerFileReader theFileReader;

		protected override void configure(FileScenarioDefinition scenario)
		{
			scenario.Asset(BaseFileName, BaseContents);
		}

		[Test]
		public void simple_append_transformer()
		{
			var transformers = new[]
			{
				new AppendToTransformer {ContentToAppend = SecondContents}
			};

			theFileReader = createFileReader(transformers);
			var contents = theFileReader.GetFileContents(BaseFileName);
			contents.ShouldEqual("{0}\r\n{1}\r\n".ToFormat(BaseContents, SecondContents));
		}

		[Test]
		public void non_matching_append_transformer()
		{
			var transformers = new[]
			{
				new NonMatchingTransformer()
			};

			theFileReader = createFileReader(transformers);
			var contents = theFileReader.GetFileContents(BaseFileName);
			contents.ShouldEqual(BaseContents);
		}

		[Test]
		public void multiple_append_transformer()
		{
			var transformers = new[]
			{
				new AppendToTransformer {ContentToAppend = SecondContents},
				new AppendToTransformer {ContentToAppend = SecondContents}
			};

			theFileReader = createFileReader(transformers);
			var contents = theFileReader.GetFileContents(BaseFileName);
			contents.ShouldEqual("{0}\r\n{1}\r\n\r\n{1}\r\n".ToFormat(BaseContents, SecondContents));
		}

		[Test]
		public void file_exists()
		{
			theFileReader = createFileReader();
			theFileReader.DoesFileExist(BaseFileName).ShouldBeTrue();
		}

		[Test]
		public void retrieves_binary_content()
		{
			theFileReader = createFileReader();
			theFileReader.GetBinaryFileContents(BaseFileName).ShouldEqual(Encoding.UTF8.GetBytes(BaseContents));
		}

		private LessFileTransformerFileReader createFileReader(IEnumerable<IFileTransformer> transformers = null)
		{
			return new LessFileTransformerFileReader(new StubPathResolver(theScenario.Directory), transformers, new FileSystem());
		}
	}

	public class StubPathResolver : IPathResolver
	{
		private readonly string _directory;

		public StubPathResolver(string directory)
		{
			_directory = directory;
		}

		public string GetFullPath(string path)
		{
			return Path.Combine(_directory, path);
		}
	}

	public class AppendToTransformer : IFileTransformer
	{
		public string ContentToAppend { get; set; }

		public bool CanTransform(string name)
		{
			return true;
		}

		public string Transform(string name, string content)
		{
			return new StringBuilder(content).AppendLine().AppendLine(ContentToAppend).ToString();
		}
	}

	public class NonMatchingTransformer : IFileTransformer
	{
		public bool CanTransform(string name)
		{
			return false;
		}

		public string Transform(string name, string content)
		{
			return new StringBuilder(content).AppendLine().AppendLine("ShouldNotAppend").ToString();
		}
	}
}
