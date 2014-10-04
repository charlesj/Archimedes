namespace Archimedes.Web.Controllers
{
	using System;
	using System.Collections.Generic;

	using Archimedes.Business.BusinessObjects;
	using Archimedes.Business.Commands.JournalCommands;
	using Archimedes.Web.Results;

	public class JournalController : ApplicationController
    {
		public AjaxResult Entries()
		{
			var request = new GetUserEntriesRequest { UserId = this.LoggedInUser.UserId };
			return this.ProcessRequest<GetUserEntriesRequest, List<JournalEntry>>(request);
		}

		public AjaxResult AdduserEntry(string content, DateTime entryDate)
		{
			var request = new AddJournalEntryRequest
				              {
					              Content = content,
					              EntryDate = entryDate,
					              UserId = this.LoggedInUser.UserId
				              };
			return this.ProcessRequest<AddJournalEntryRequest, JournalEntry>(request);
		}

		public AjaxResult UpdateEntryChanges(int id, string content, DateTime entryDate)
		{
			var request = new SaveJournalEntryChangesRequest
				              {
					              Content = content,
					              EntryDate = entryDate,
					              JournalEntryId = id,
					              RequestingUserId = this.LoggedInUser.UserId
				              };
			return this.ProcessRequest<SaveJournalEntryChangesRequest, JournalEntry>(request);
		}

		public AjaxResult DeleteEntry(int id)
		{
			var request = new DeleteJournalEntryRequest { JournalEntryId = id, RequestingUserId = this.LoggedInUser.UserId };
			return this.ProcessRequest<DeleteJournalEntryRequest, bool>(request);
		}
    }
}