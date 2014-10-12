namespace Archimedes.Data.MemoryRepositories
{
	using System.Collections.Generic;
	using System.Linq;

	using Archimedes.Data.Contracts;
	using Archimedes.Data.Models;

	public class UserActivityRepository : MemoryRepository<UserActivity>, IUserActivityRepository
	{
		public IEnumerable<UserActivity> GetUserActivity(int userId)
		{
			return this.Storage.Values.Where(activity => activity.UserId == userId);
		}
	}
}
