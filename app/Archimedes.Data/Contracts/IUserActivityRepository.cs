namespace Archimedes.Data.Contracts
{
	using System.Collections.Generic;

	using Models;

	public interface IUserActivityRepository : IRepository<UserActivity>
	{
		IEnumerable<UserActivity> GetUserActivity(int userId);
	}
}