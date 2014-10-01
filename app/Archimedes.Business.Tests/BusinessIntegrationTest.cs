namespace Archimedes.Business.Tests
{
	using Archimedes.Common;
	using Archimedes.Common.Tests;
	using Archimedes.Data.Contracts;

	public class BusinessIntegrationTest<TSut> : BaseIntegrationTest<TSut>
	{
		public BusinessIntegrationTest()
		{
			this.Data = Bootstrapper.BootedKernel.ServiceLocator.GetService<IDataStorage>();
		}
		
		protected IDataStorage Data { get; private set; }
	}
}
