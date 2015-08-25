using Xunit;

namespace Archimedes.Business.Tests.Commands
{
	using System.Collections.Generic;
	using Business.Commands;
	using Common.Commands;
	using Data.Models;

	public class GetRulesCommandTests : BusinessIntegrationTest<BaseCommand<GetRulesRequest, List<Rule>>>
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
	}
}
