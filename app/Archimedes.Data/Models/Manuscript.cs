namespace Archimedes.Data.Models
{
	using System;

	public class Manuscript : IModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime LastUpdated { get; set; }
	}
}
