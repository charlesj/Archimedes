namespace Archimedes.Data.Models
{
	using System;

	public class UserActivity : IModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public string ObjectType { get; set; }

		public int ObjectId { get; set; }

		public string Description { get; set; }

		public DateTime CreatedOn { get; set; }
	}
}
