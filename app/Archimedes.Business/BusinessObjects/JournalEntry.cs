namespace Archimedes.Business.BusinessObjects
{
	using System;

	public class JournalEntry
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime EntryDate { get; set; }
	}
}
