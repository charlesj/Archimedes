namespace Archimedes.Business.Tests.Commands.JournalCommandTests
{
	using System.Linq;

	using Archimedes.Business.Commands.JournalCommands;
	using Archimedes.Common.Commands;

	using Xunit;

	public class GetUserEntriesCommandTests : BusinessIntegrationTest<GetUserEntriesCommand>
	{
		[Fact]
		public void CanExecuteCommand()
		{
			var user = this.Data.Users.GetAll().First();
			var req = new GetUserEntriesRequest { UserId = user.Id };
			var result = this.SystemUnderTest.Execute(req);
			Assert.Equal(result.ResultType, ResponseTypes.Success);
		}

		[Fact]
		public void ReturnsSomeResults()
		{
			var user = this.Data.Users.GetAll().First();
			var req = new GetUserEntriesRequest { UserId = user.Id };
			var result = this.SystemUnderTest.Execute(req);
			Assert.True(result.Result.Any());
		}
	}
}
