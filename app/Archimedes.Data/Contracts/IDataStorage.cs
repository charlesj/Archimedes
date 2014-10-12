namespace Archimedes.Data.Contracts
{
	public interface IDataStorage
	{
		IJournalEntryRepository JournalEntries { get; }

		IManuscriptRepository Manuscripts { get; }

		IUserActivityRepository UserActivities { get; }

		IUserRepository Users { get; }

		IUserSettingsRepository UserSettings { get;}
	}
}