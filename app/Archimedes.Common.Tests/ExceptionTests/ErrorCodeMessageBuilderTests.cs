namespace Archimedes.Common.Tests.ExceptionTests
{
	using System;

	using ErrorCodes;
	using Exceptions;

	using Xunit;

	public class ErrorCodeMessageBuilderTests : BaseIntegrationTest<IErrorCodeMessageBuilder>
	{
		/// If an exception is passed in that is not an error code exception, then it should just
		/// return the default message.
		[Fact]
		public void NonErrorCodeExceptionReturnsDefaultMessage()
		{
			var exception = new Exception();
			var userInfo = this.SystemUnderTest.BuildUserInformation(
				exception,
				TestResouces.ResourceManager,
				"default message");

			Assert.Equal("default message", userInfo.Message);
			Assert.Null(userInfo.Instance);
			Assert.Null(userInfo.Code);
		}

		/// If the resource manager is null, we should return the default error message, but with 
		/// the error code information from the exception filled out.
		[Fact]
		public void IfResourceManagerIsNullDefaultMessageIsReturnedWithErrorCodeInformation()
		{
			var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
			var userInfo = this.SystemUnderTest.BuildUserInformation(exception, null, "default message");
			Assert.Equal("default message", userInfo.Message);
			Assert.Equal(CommonErrors.MissingApplicationConfiguration.FullIdentifier, userInfo.Code);
			Assert.Equal(exception.InstanceIdentifier.ToString(), userInfo.Instance);
		}

		/// If the resource passed in does have a match, it's value should be returned.
		[Fact]
		public void MessageFromResourceIsUsedIfAvailable()
		{
			var exception = new ErrorCodeException(CommonErrors.CouldNotLocateCommand);
			var userInfo = this.SystemUnderTest.BuildUserInformation(exception, TestResouces.ResourceManager, "default message");
			Assert.Equal("You're insane!  You know that, right?", userInfo.Message);
		}

		/// If the exception has a formatting object, it is used to format the message.
		[Fact]
		public void MessageFromResourceIsFormattedIfPossible()
		{
			var formattingObject = new { name = "Fozzy" };
			var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration, formattingObject);
			var userInfo = this.SystemUnderTest.BuildUserInformation(exception, TestResouces.ResourceManager, "default message");
			Assert.Equal("Hello, Fozzy", userInfo.Message);
		}
	}
}