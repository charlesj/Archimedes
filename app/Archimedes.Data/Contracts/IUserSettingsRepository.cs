namespace Archimedes.Data.Contracts
{
	using Models;

	public interface IUserSettingsRepository : IRepository<UserSettings>
	{
		UserSettings GetForUser(int userId);

		bool UserHasSettings(int userId);
	}
}