namespace Archimedes.Data
{
	using Contracts;
	using MemoryRepositories;

	using Ninject.Modules;

	public class DataNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IDataStorage>().To<DataStorage>().InSingletonScope();

			this.Bind<IRuleRepository>().To<RuleRepository>();
		}
	}
}