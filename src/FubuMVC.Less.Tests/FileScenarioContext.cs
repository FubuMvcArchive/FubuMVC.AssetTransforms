using NUnit.Framework;

namespace FubuMVC.Less.Tests
{
	public class FileScenarioContext
	{
		protected FileScenario theScenario;

		[SetUp]
		public void SetUp()
		{
			theScenario = FileScenario.Create(configure);
		}

		protected virtual void configure(FileScenarioDefinition fileScenario)
		{
		}

		[TearDown]
		public void TearDown()
		{
			theScenario.Cleanup();
		}
	}
}
