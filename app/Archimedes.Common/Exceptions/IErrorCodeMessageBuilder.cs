namespace Archimedes.Common.Exceptions
{
    using System;
    using System.Resources;

    public interface IErrorCodeMessageBuilder
    {
        ErrorCodeUserInformation BuildUserInformation(
            Exception exception,
            ResourceManager errorCodeResources,
            string defaultMessage);
    }
}
