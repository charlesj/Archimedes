namespace Archimedes.Data.MemoryRepositories
{
	using System.Linq;

	using Archimedes.Data.Contracts;
	using Archimedes.Data.Models;

	public class UserRepository : MemoryRepository<User>, IUserRepository
	{
		public UserRepository()
		{
			this.Insert(new User { Username = "charlesj" });
			this.Insert(new User { Username = "jmcqk6" });
		}

		public User GetByUsername(string username)
		{
			return this.Storage.Single(u => u.Value.Username == username).Value;
		}

		public bool Validate(string username, string password)
		{
			return this.Storage.Any(sp => sp.Value.Username == username);
		}
	}
}
