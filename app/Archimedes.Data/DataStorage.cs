namespace Archimedes.Data
{
	using Archimedes.Data.Contracts;

	using Ninject;

	public class DataStorage : IDataStorage
	{
		[Inject]
		public IManuscriptRepository Manuscripts { get; set; }
	}
}
