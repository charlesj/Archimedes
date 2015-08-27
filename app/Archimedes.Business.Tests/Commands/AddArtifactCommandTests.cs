using Xunit;

namespace Archimedes.Business.Tests.Commands
{
	using Business.Commands;
	using Common.Commands;
	using Data.Models;

	public class AddArtifactCommandTests : BusinessIntegrationTest<BaseCommand<AddArtifactRequest, Artifact>>
	{
		[Fact]
		public void CanInstatiateTheSut()
		{
			Assert.NotNull(this.SystemUnderTest);
		}

		[Fact]
		public void CanExecuteTheCommand()
		{
			var request = new AddArtifactRequest
			{
				Motivation = "Test test test",
				Source = "Fozzy",
				Status = "Suggested",
				Title = "This test rule should not be persisted"
			};

			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, response.ResultType);
		}
	}
}
