namespace Archimedes.Business.Tests.Commands
{
	using Business.Commands;
	using Common.Commands;
	using Xunit;

	public class GetArtifactCommandTests : BusinessIntegrationTest<BaseCommand<GetPagedArtifactsRequest, GetPagedArtifactsResponse>>
	{
		[Fact]
		public void CanInstantiateCommand()
		{
			Assert.NotNull(this.SystemUnderTest);
		}
		 
		[Fact]
		public void CanExecuteWithBasicRequest()
		{
			var request = new GetPagedArtifactsRequest {PageSize = 5, StartIndex = 0};
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, response.ResultType);
		}

		[Fact]
		public void IfRequestContainsInvalidPageValuesReturnInvalidResult()
		{
			var request = new GetPagedArtifactsRequest {PageSize = 0, StartIndex = -1};
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.InvalidRequest, response.ResultType);
		}

		[Fact]
		public void IfPageSizeIsSetResultsContainNoMoreThanPageSize()
		{
			var request = new GetPagedArtifactsRequest { PageSize = 10, StartIndex = 0 };
			var response = this.SystemUnderTest.Execute(request);
			Assert.True(response.Result.Artifacts.Count <= 10);
		}
	}
}