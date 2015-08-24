namespace Archimedes.Data
{
	using Contracts;

	using Ninject;

	public class DataStorage : IDataStorage
	{
		[Inject]
		public IRuleRepository Rules { get; set; }
	}
}