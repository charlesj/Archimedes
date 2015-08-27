namespace Archimedes.Business.Tests.Commands
{
	using Business.Commands;
	using Common.Commands;
	using Xunit;

	public class GetArtifactCommandTests : BusinessIntegrationTest<BaseCommand<GetArtifactsRequest, GetArtifactsResponse>>
	{
		[Fact]
		public void CanInstantiateCommand()
		{
			Assert.NotNull(this.SystemUnderTest);
		}
		 
		[Fact]
		public void CanExecuteWithBasicRequest()
		{
			var request = new GetArtifactsRequest();
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, response.ResultType);
		}

		[Fact]
		public void IfRequestContainsInvalidPageValuesReturnInvalidResult()
		{
			var request = new GetArtifactsRequest {PageSize = 0, StartIndex = -1};
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.InvalidRequest, response.ResultType);
		}

		[Fact]
		public void IfOnlyOnePageResponseIsSetReturnInvalidResult()
		{
			var request = new GetArtifactsRequest { PageSize = 10 };
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.InvalidRequest, response.ResultType);
		}

		[Fact]
		public void IfPageSizeIsSetResultsContainNoMoreThanPageSize()
		{
			var request = new GetArtifactsRequest { PageSize = 10, StartIndex = 0 };
			var response = this.SystemUnderTest.Execute(request);
			Assert.True(response.Result.Artifacts.Count <= 10);
		}
	}
}