namespace Archimedes.Data.Models
{
	using System;

	public class JournalEntry : IModel
	{
		public int Id { get; set; }

		public int Userid { get; set; }

		public string Content { get; set; }

		public DateTime CreatedOn { get; set; }
	}
}
