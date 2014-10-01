namespace Archimedes.Business.Tests
{
	using Archimedes.Business.Commands.ManuscriptCommands;
	using Archimedes.Common.Tests;

	using Xunit;

	public class CreateManuscriptCommandTests : BaseIntegrationTest<CreateManuscriptCommand>
    {
		[Fact]
		public void CanExecute()
		{
			this.SystemUnderTest.Execute(new CreateManuscriptRequest{Description = "wokka", Title = "wokka wokka"});
		}
    }
}
