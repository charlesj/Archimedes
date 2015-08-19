namespace Archimedes.Common.Tests.ExceptionTests
{
    using System;

    using Archimedes.Common.ErrorCodes;
    using Archimedes.Common.Exceptions;

    using Xunit;

    public class ErrorCodeExceptionTests
    {
        /// <summary>
        /// Make sure that the error code is being set on the basic usage.
        /// </summary>
        [Fact]
        public void ErrorCodeExceptionSetsErrorCode()
        {
            var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
            Assert.NotNull(exception.ErrorCode);
        }

        /// <summary>
        /// The behavior of the formatting object is important because it helps determine
        /// how the user message is generated.  So, we want to make sure the behavior is
        /// tested to make sure it doesn't change.
        /// </summary>
        [Fact]
        public void NoFormattingObjectMeansPropertyIsNull()
        {
            var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
            Assert.Null(exception.FormattingObject);
        }

        /// <summary>
        /// The error code exception sets formatting object.
        /// </summary>
        [Fact]
        public void ErrorCodeExceptionSetsFormattingObject()
        {
            var formattingObject = new { formatting = true, yes = "this has a value" };
            var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration, formattingObject);
            Assert.Equal(formattingObject, exception.FormattingObject);
        }

        /// <summary>
        /// The instance identifier should be unique
        /// </summary>
        [Fact]
        public void InstanceIdentifierNotEmpty()
        {
            var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
            Assert.NotEqual(Guid.Empty, exception.InstanceIdentifier);
        }

        /// <summary>
        /// The instance identifer should be different every time the exception is instantiated.
        /// </summary>
        [Fact]
        public void InstanceIdentiferDifferentOnDifferentInstances()
        {
            var exception_one = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
            var exception_two = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
            Assert.NotEqual(exception_one.InstanceIdentifier, exception_two.InstanceIdentifier);
        }

        /// <summary>
        /// The message is set to default if none is provided.
        /// </summary>
        [Fact]
        public void MessageIsSetToDefaultIfNoneIsProvided()
        {
            var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration);
            var expectedMessage = string.Format("{0} - {1}", CommonErrors.MissingApplicationConfiguration.FullIdentifier, CommonErrors.MissingApplicationConfiguration.ShortDescription);
            Assert.Equal(expectedMessage, exception.Message);
        }

        /// <summary>
        /// If there is a message provided, we want to use that message, not the default message.
        /// </summary>
        [Fact]
        public void MessageIsSetIfItsProvided()
        {
            var exception = new ErrorCodeException(CommonErrors.MissingApplicationConfiguration, "It's a message");
            Assert.Equal("It's a message", exception.Message);
        }
    }
}
