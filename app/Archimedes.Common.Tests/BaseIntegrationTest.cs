namespace Archimedes.Common.Tests
{
	public class BaseIntegrationTest<TSut>
	{
		public BaseIntegrationTest()
		{
			Bootstrapper.Boot(BootConfiguration.DefaultConfiguration);
			this.SystemUnderTest = Bootstrapper.BootedKernel.ServiceLocater.GetService<TSut>();
		}

		public TSut SystemUnderTest { get; set; }
	}
}
