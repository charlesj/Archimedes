namespace Archimedes.Data.Contracts
{
	using System.Collections.Generic;

	using Archimedes.Data.Models;

	public interface IUserActivityRepository : IRepository<UserActivity>
	{
		IEnumerable<UserActivity> GetUserActivity(int userId);
	}
}