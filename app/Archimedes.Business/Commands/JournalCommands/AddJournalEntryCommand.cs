namespace Archimedes.Business.Commands.JournalCommands
{
	using System;

	using Archimedes.Business.BusinessObjects;

	/// <summary>
	/// The add journal entry command.
	/// </summary>
	public class AddJournalEntryCommand : BusinessCommand<AddJournalEntryRequest, JournalEntry>
	{
		public AddJournalEntryCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		protected override JournalEntry Work()
		{
			var model = this.Mapper.Map<AddJournalEntryRequest, Data.Models.JournalEntry>(this.Request);
			var newEntry = this.DataStore.JournalEntries.Insert(model);
			this.UserActivityLog.LogUserActivity(model.Userid, "JournalEntry", newEntry.Id, "Wrote in journal");
			var mapped = this.Mapper.Map<Data.Models.JournalEntry, JournalEntry>(newEntry);
			return mapped;
		}
	}
}