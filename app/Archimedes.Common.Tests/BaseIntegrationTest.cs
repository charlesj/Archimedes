namespace Archimedes.Common.Tests
{
	public class BaseIntegrationTest<TSut>
	{
		public BaseIntegrationTest()
		{
			Kernel.Boot(BootConfiguration.DefaultConfiguration);
			this.SystemUnderTest = Kernel.ServiceLocator.GetService<TSut>();
		}

		public TSut SystemUnderTest { get; set; }
	}
}