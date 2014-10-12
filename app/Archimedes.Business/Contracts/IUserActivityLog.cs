namespace Archimedes.Business.Contracts
{
	public interface IUserActivityLog
	{
		void LogUserActivity(int userId, string objectType, int objectId, string description);
	}
}