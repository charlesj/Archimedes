namespace Archimedes.Data
{
	using Archimedes.Data.Contracts;
	using Archimedes.Data.MemoryRepositories;

	using Ninject.Modules;

	public class DataNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IDataStorage>().To<DataStorage>().InSingletonScope();

			this.Bind<IJournalEntryRepository>().To<JournalEntryRepository>();
			this.Bind<IManuscriptRepository>().To<ManuscriptRepository>();
			this.Bind<IUserActivityRepository>().To<UserActivityRepository>();
			this.Bind<IUserRepository>().To<UserRepository>();
			this.Bind<IUserSettingsRepository>().To<UserSettingsRepository>();
		}
	}
}
