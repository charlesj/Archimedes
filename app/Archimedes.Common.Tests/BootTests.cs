namespace Archimedes.Common.Tests
{
	using Xunit;

	public class BootTests
    {
		[Fact]
		public void CanBoot()
		{
			Bootstrapper.Boot(BootConfiguration.DefaultConfiguration);
		}
    }
}