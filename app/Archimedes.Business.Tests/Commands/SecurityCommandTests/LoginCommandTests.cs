namespace Archimedes.Business.Tests.Commands.SecurityCommandTests
{
	using Archimedes.Business.Commands.SecurityCommands;
	using Archimedes.Common.Commands;
	using Archimedes.Common.Tests;

	using Xunit;

	public class LoginCommandTests : BaseIntegrationTest<LoginCommand>
	{
		[Fact]
		public void CanLoginUsingValidCredentials()
		{
			var request = new LoginRequest { Username = "charlesj", Password = "unused" };
			var result = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, result.ResultType);
			Assert.True(result.Result);
		}
	}
}
