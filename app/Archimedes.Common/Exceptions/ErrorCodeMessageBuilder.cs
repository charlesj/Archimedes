namespace Archimedes.Common.Exceptions
{
    using System;
    using System.Resources;

    using Archimedes.Common.Extensions;

    /// <summary>
    /// This builder is used to build the information available to end users.  
    /// </summary>
    public class ErrorCodeMessageBuilder : IErrorCodeMessageBuilder
    {
        /// <summary>
        /// Builds the user facing information based on the passed in values.  Applications are not required to have a custom
        /// message for every ErrorCode, so we ask for a default message.  
        /// </summary>
        /// <param name="exception">
        /// The exception.  If the exception is not an ErrorCodeException, only 
        /// the message property on the return type will have a value.
        /// </param>
        /// <param name="errorCodeResources">
        /// The error code messages.  This is the resx file that contains the relevant user messages.
        /// </param>
        /// <param name="defaultMessage">
        /// The default message.  If the resx file does not contain a value for the given code, the default message is used instead.
        /// </param>
        /// <returns>
        /// The <see cref="ErrorCodeUserInformation"/>.
        /// </returns>
        public ErrorCodeUserInformation BuildUserInformation(Exception exception, ResourceManager errorCodeResources, string defaultMessage)
        {
            var userInformation = new ErrorCodeUserInformation { Message = defaultMessage };
            var codeException = exception as ErrorCodeException;

            if (codeException == null)
            {
                return userInformation;
            }

            var errorCode = codeException.ErrorCode;
            userInformation.Instance = codeException.InstanceIdentifier.ToString();
            userInformation.Code = errorCode.FullIdentifier;

            if (errorCodeResources == null)
            {
                return userInformation;
            }

            var localized = errorCodeResources.GetString(errorCode.FullIdentifier);
            if (string.IsNullOrEmpty(localized))
            {
                return userInformation;
            }

            if (codeException.FormattingObject == null)
            {
                userInformation.Message = localized;
            }
            else
            {
                userInformation.Message = localized.FormatWith(codeException.FormattingObject);
            }

            return userInformation;
        }
    }
}