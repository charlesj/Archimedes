namespace Archimedes.Business.Tests
{
	using Archimedes.Business.Commands.ManuscriptCommands;
	using Archimedes.Common.Commands;
	using Archimedes.Common.Tests;

	using Xunit;

	public class GetAllManuscriptsCommandTests : BaseIntegrationTest<GetAllManuscriptsCommand>
    {
		[Fact]
		public void CanExecute()
		{
			var result = this.SystemUnderTest.Execute(new GetAllManuscriptsRequest());
			Assert.Equal(ResponseTypes.Success, result.ResultType);
		}
    }
}
