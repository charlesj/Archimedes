namespace Archimedes.Data.Tests
{
	using System;
	using System.Linq;

	using Archimedes.Common.Extensions;
	using Archimedes.Common.Tests;

	using Xunit;

	public class DataStorageTests : BaseIntegrationTest<DataStorage>
	{
		[Fact]
		public void AllRepositoriesAreNotNull()
		{
			var repositories = this.SystemUnderTest.GetProperties().Where(p => p.PropertyType.Name.Contains("Repository"));
			foreach (var repository in repositories)
			{
				Console.WriteLine("Checking {0}", repository.Name);
				var value = repository.GetValue(this.SystemUnderTest);
				Assert.NotNull(value);
			}
		}
	}
}