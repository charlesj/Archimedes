namespace Archimedes.Business.Services
{
	using System;

	using Archimedes.Business.Contracts;
	using Archimedes.Data.Contracts;
	using Archimedes.Data.Models;

	/// <summary>
	/// The user activity log.
	/// </summary>
	public class UserActivityLog : IUserActivityLog
	{
		/// <summary>
		/// The data storage.
		/// </summary>
		private readonly IDataStorage dataStorage;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserActivityLog"/> class.
		/// </summary>
		/// <param name="dataStorage">
		/// The data storage.
		/// </param>
		public UserActivityLog(IDataStorage dataStorage)
		{
			this.dataStorage = dataStorage;
		}

		/// <summary>
		/// Logs a user activity for their activity feed.
		/// </summary>
		/// <param name="userId">
		/// The user id.
		/// </param>
		/// <param name="objectType">
		/// The object type.
		/// </param>
		/// <param name="objectId">
		/// The object id.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		public void LogUserActivity(int userId, string objectType, int objectId, string description)
		{
			var activity = new UserActivity
				               {
					               CreatedOn = DateTime.Now,
					               Description = description,
					               ObjectId = objectId,
					               ObjectType = objectType,
					               UserId = userId
				               };
			this.dataStorage.UserActivities.Insert(activity);
		}
	}
}
