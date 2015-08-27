using System;
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
				Title = "This test rule should not be persisted",
				Description = "asdf",
				Link = "asdf"
			};

			var response = this.SystemUnderTest.Execute(request);
			Assert.Equal(ResponseTypes.Success, response.ResultType);
		}

		[Fact]
		public void WhenInsertingArtifactCreatedOnIsSet()
		{
			var request = new AddArtifactRequest
			{
				Title = "This test rule should not be persisted",
				Description = "asdf",
				Link = "asdf"
			};

			var response = this.SystemUnderTest.Execute(request);
			Assert.True(response.Result.CreatedOn.Date == DateTime.Now.Date);
		}
	}
}
