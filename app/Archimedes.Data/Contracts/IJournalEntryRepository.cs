namespace Archimedes.Data.Contracts
{
	using System.Collections.Generic;

	using Models;

	public interface IJournalEntryRepository : IRepository<JournalEntry>
	{
		IEnumerable<JournalEntry> GetUsersEntries(int userId);
	}
}