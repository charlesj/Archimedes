namespace Archimedes.Business.Tests.Commands.JournalCommandTests
{
	using System.Linq;

	using Archimedes.Business.Commands.JournalCommands;
	using Archimedes.Common.Commands;

	using Xunit;

	public class SaveJournalEntryChangesCommandTests : BusinessIntegrationTest<SaveJournalEntryChangesCommand>
	{
		[Fact]
		public void CanExecuteCommand()
		{
			var user = this.Data.Users.GetAll().First();
			var journalEntry = this.Data.JournalEntries.GetAll().First(j => j.Userid == user.Id);
			var request = new SaveJournalEntryChangesRequest
				              {
					              Content = "Edited and Changed",
					              EntryDate = journalEntry.EntryDate,
					              JournalEntryId = journalEntry.Id,
					              RequestingUserId = user.Id
				              };

			var result = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, result.ResultType);
		}
	}
}
