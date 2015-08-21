namespace Archimedes.Common.Exceptions
{
	using System;
	using System.Resources;

	using Extensions;

	public class ErrorCodeMessageBuilder : IErrorCodeMessageBuilder
	{
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