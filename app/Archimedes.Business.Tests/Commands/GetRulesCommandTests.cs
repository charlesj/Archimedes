using Xunit;

namespace Archimedes.Business.Tests.Commands
{
	using Business.Commands;
	using Common.Commands;

	public class GetRulesCommandTests : BusinessIntegrationTest<BaseCommand<GetRulesRequest, GetRulesResponse>>
	{
		[Fact]
		public void CanInstantiateCommand()
		{
			Assert.NotNull(this.SystemUnderTest);
		}
		 
		[Fact]
		public void CanExecuteWithBasicRequest()
		{
			var request = new GetRulesRequest();
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, response.ResultType);
		}

		[Fact]
		public void IfRequestContainsInvalidPageValuesReturnInvalidResult()
		{
			var request = new GetRulesRequest {PageSize = 0, StartIndex = -1};
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.InvalidRequest, response.ResultType);
		}

		[Fact]
		public void IfOnlyOnePageResponseIsSetReturnInvalidResult()
		{
			var request = new GetRulesRequest { PageSize = 10 };
			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.InvalidRequest, response.ResultType);
		}

		[Fact]
		public void IfPageSizeIsSetResultsContainNoMoreThanPageSize()
		{
			var request = new GetRulesRequest { PageSize = 10, StartIndex = 0 };
			var response = this.SystemUnderTest.Execute(request);
			Assert.True(response.Result.FoundRules.Count <= 10);
		}
	}
}
