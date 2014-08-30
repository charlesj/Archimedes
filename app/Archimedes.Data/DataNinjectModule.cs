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

			this.Bind<IManuscriptRepository>().To<ManuscriptRepository>();
		}
	}
}
