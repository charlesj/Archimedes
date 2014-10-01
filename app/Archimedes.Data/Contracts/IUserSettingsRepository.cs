namespace Archimedes.Data.Contracts
{
	using Archimedes.Data.Models;

	public interface IUserSettingsRepository : IRepository<UserSettings>
	{
		UserSettings GetForUser(int userId);

		bool UserHasSettings(int userId);
	}
}
