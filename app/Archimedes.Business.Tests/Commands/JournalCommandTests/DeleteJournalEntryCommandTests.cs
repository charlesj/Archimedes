namespace Archimedes.Business.Tests.Commands.JournalCommandTests
{
	using System.Linq;

	using Archimedes.Business.Commands.JournalCommands;
	using Archimedes.Common.Commands;

	using Xunit;

	public class DeleteJournalEntryCommandTests : BusinessIntegrationTest<DeleteJournalEntryCommand>
	{
		[Fact]
		public void CanExecuteCommand()
		{
			var user = this.Data.Users.GetAll().First();
			var journalEntry = this.Data.JournalEntries.GetAll().First(j => j.Userid == user.Id);
			var request = new DeleteJournalEntryRequest { RequestingUserId = user.Id, JournalEntryId = journalEntry.Id };
			var result = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, result.ResultType);
		}
	}
}
