namespace Archimedes.Data.Tests
{
	using Archimedes.Common;

	using Xunit;

	public class DataBootTests
    {
	    [Fact]
	    public void CanBootWithData()
	    {
		    Bootstrapper.Boot(BootConfiguration.DefaultConfiguration);
	    }
    }
}
