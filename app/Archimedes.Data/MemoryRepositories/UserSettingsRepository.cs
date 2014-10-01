namespace Archimedes.Data.MemoryRepositories
{
	using System.Linq;

	using Archimedes.Data.Contracts;
	using Archimedes.Data.Models;

	public class UserSettingsRepository : MemoryRepository<UserSettings>, IUserSettingsRepository
	{
		public UserSettingsRepository()
		{
			this.Insert(new UserSettings { UserId = 1 });
		}

		public UserSettings GetForUser(int userId)
		{
			return this.Storage.Single(s => s.Value.UserId == userId).Value;
		}

		public bool UserHasSettings(int userId)
		{
			return this.Storage.Any(s => s.Value.UserId == userId);
		}
	}
}
