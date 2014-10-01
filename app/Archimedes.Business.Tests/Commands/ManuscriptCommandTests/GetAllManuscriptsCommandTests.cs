namespace Archimedes.Business.Tests
{
	using Archimedes.Business.Commands.ManuscriptCommands;
	using Archimedes.Common.Tests;

	using Xunit;

	public class GetAllManuscriptsCommandTests : BaseIntegrationTest<GetAllManuscriptsCommand>
    {
		[Fact]
		public void CanExecute()
		{
			this.SystemUnderTest.Execute(new GetAllManuscriptsRequest());
		}
    }
}
