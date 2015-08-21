namespace Archimedes.Data.Models
{
	using System;

	public class User : IModel
	{
		public int Id { get; set; }

		public string Username { get; set; }

		public DateTime LastLoggedIn { get; set; }

		public int RoleId { get; set; }
	}
}