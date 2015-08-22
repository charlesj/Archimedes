namespace Archimedes.Data.Tests
{
	using Common;

	using Xunit;

	public class DataBootTests
	{
		[Fact]
		public void CanBootWithData()
		{
			Kernel.Boot(BootConfiguration.DefaultConfiguration);
		}
	}
}