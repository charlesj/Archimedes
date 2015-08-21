namespace Archimedes.Data.MemoryRepositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Models;

	public class JournalEntryRepository : MemoryRepository<JournalEntry>, IJournalEntryRepository
	{
		public JournalEntryRepository()
		{
			this.Insert(new JournalEntry { EntryDate = new DateTime(2012, 1, 13), Content = "I'm moving to oregon!!!!", Userid = 1 });
			this.Insert(new JournalEntry { EntryDate = new DateTime(2012, 4, 1), Content = "I see mountains! I moved to Oregon!", Userid = 1 });
			this.Insert(new JournalEntry { EntryDate = new DateTime(2012, 4, 10), Content = "I saw the mother fucking ocean, bitches!", Userid = 2 });
		}
		public IEnumerable<JournalEntry> GetUsersEntries(int userId)
		{
			return this.Storage.Values.Where(entry => entry.Userid == userId);
		}
	}
}