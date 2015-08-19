namespace Archimedes.Common.Exceptions
{
    using System;
    using System.Resources;

    /// <summary>
    /// The ErrorCodeMessageBuilder interface.  This interface is used to build an object that can be sent to the 
    /// user based on error codes, especially localized / formatted.
    /// </summary>
    public interface IErrorCodeMessageBuilder
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
        ErrorCodeUserInformation BuildUserInformation(
            Exception exception,
            ResourceManager errorCodeResources,
            string defaultMessage);
    }
}