namespace Archimedes.Data.Tests
{
	using System.Linq;

	using Common.Tests;
	using Contracts;
	using Models;

	using Xunit;

	public class RulesRepositoryTests : BaseIntegrationTest<IRuleRepository>
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
			var rule = new Rule();
			this.SystemUnderTest.Insert(rule);
			var newCount = this.SystemUnderTest.GetAll().Count();
			Assert.True(newCount == currentCount + 1);
		}

		[Fact]
		public void RepositoryCanUpdate()
		{
			var rule = new Rule();
			this.SystemUnderTest.Insert(rule);
			var newMan = new Rule { Id = rule.Id, Title = "New Title" };
			this.SystemUnderTest.Update(newMan);
			Assert.True(this.SystemUnderTest.Get(rule.Id).Title == "New Title");
		}

		[Fact]
		public void RepositoryCanDelete()
		{
			var rule = new Rule();
			rule = this.SystemUnderTest.Insert(rule);
			var currentCount = this.SystemUnderTest.GetAll().Count();
			
			this.SystemUnderTest.Delete(rule.Id);
			var newCount = this.SystemUnderTest.GetAll().Count();
			Assert.True(newCount == currentCount - 1);
		}
	}
}