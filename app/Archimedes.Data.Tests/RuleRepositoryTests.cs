namespace Archimedes.Data.Tests
{
	using System.Linq;

	using Common.Tests;
	using Contracts;
	using Models;

	using Xunit;

	public class ArtifactRepositoryTests : BaseIntegrationTest<IArtifactRepository>
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
			var artifact = new Artifact();
			this.SystemUnderTest.Insert(artifact);
			var newCount = this.SystemUnderTest.GetAll().Count();
			Assert.True(newCount == currentCount + 1);
		}

		[Fact]
		public void RepositoryCanUpdate()
		{
			var artifact = new Artifact();
			this.SystemUnderTest.Insert(artifact);
			var newMan = new Artifact { Id = artifact.Id, Title = "New Title" };
			this.SystemUnderTest.Update(newMan);
			Assert.True(this.SystemUnderTest.Get(artifact.Id).Title == "New Title");
		}

		[Fact]
		public void RepositoryCanDelete()
		{
			var artifact = new Artifact();
			artifact = this.SystemUnderTest.Insert(artifact);
			var currentCount = this.SystemUnderTest.GetAll().Count();
			
			this.SystemUnderTest.Delete(artifact.Id);
			var newCount = this.SystemUnderTest.GetAll().Count();
			Assert.True(newCount == currentCount - 1);
		}
	}
}