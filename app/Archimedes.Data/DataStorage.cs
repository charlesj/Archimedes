namespace Archimedes.Data
{
	using Archimedes.Data.Contracts;

	using Ninject;

	public class DataStorage : IDataStorage
	{
		[Inject]
		public IJournalEntryRepository JournalEntries { get; set; }

		[Inject]
		public IManuscriptRepository Manuscripts { get; set; }

		[Inject]
		public IUserRepository Users { get; set; }

		[Inject]
		public IUserSettingsRepository UserSettings { get; set; }
	}
}
