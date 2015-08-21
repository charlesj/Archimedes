namespace Archimedes.Business.Tests
{
	using Common;
	using Common.Tests;
	using Data.Contracts;

	public class BusinessIntegrationTest<TSut> : BaseIntegrationTest<TSut>
	{
		public BusinessIntegrationTest()
		{
			this.Data = Bootstrapper.BootedKernel.ServiceLocator.GetService<IDataStorage>();
		}
		
		protected IDataStorage Data { get; private set; }
	}
}
