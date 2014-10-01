namespace Archimedes.Data.Contracts
{
	using System.Collections.Generic;

	using Archimedes.Data.Models;

	public interface IJournalEntryRepository : IRepository<JournalEntry>
	{
		IEnumerable<JournalEntry> GetUsersEntries(int userId);
	}
}