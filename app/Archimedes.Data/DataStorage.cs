namespace Archimedes.Data
{
	using Contracts;

	using Ninject;

	public class DataStorage : IDataStorage
	{
		[Inject]
		public IArtifactRepository Artifacts { get; set; }
	}
}