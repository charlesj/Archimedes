namespace Archimedes.Data.Tests
{
	using System.Linq;

	using Archimedes.Common.Tests;
	using Archimedes.Data.MemoryRepositories;
	using Archimedes.Data.Models;

	using Xunit;

	public class ManuscriptRepositoryTests : BaseIntegrationTest<ManuscriptRepository>
	{
		[Fact]
		public void RepositoryCanGetAll()
		{
			var all = this.SystemUnderTest.GetAll();
		}

		[Fact]
		public void RepositoryCanInsert()
		{
			var currentCount = this.SystemUnderTest.GetAll().Count();
			var manuscript = new Manuscript();
			this.SystemUnderTest.Insert(manuscript);
			var newCount = this.SystemUnderTest.GetAll().Count();
			Assert.True(newCount == currentCount + 1);
		}

		[Fact]
		public void RepositoryCanUpdate()
		{
			var manuscript = new Manuscript();
			this.SystemUnderTest.Insert(manuscript);
			var newMan = new Manuscript { Id = manuscript.Id, Title = "New Title" };
			this.SystemUnderTest.Update(newMan);
			Assert.True(this.SystemUnderTest.Get(manuscript.Id).Title == "New Title");
		}

		[Fact]
		public void RepositoryCanDelete()
		{
			var manuscript = new Manuscript();
			manuscript = this.SystemUnderTest.Insert(manuscript);
			var currentCount = this.SystemUnderTest.GetAll().Count();
			
			this.SystemUnderTest.Delete(manuscript.Id);
			var newCount = this.SystemUnderTest.GetAll().Count();
			Assert.True(newCount == currentCount - 1);
		}
	}
}