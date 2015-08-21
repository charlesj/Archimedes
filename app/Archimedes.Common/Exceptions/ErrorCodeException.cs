namespace Archimedes.Common.Exceptions
{
	using System;

	public class ErrorCodeException : Exception
	{
		private readonly ErrorCode errorCode;

		private readonly Guid instanceIdentifier = Guid.NewGuid();

		private readonly object formattingObject;

		public ErrorCodeException(
			ErrorCode errorCode,
			object formattingObject = null)
			: base(errorCode.ToString())
		{
			this.formattingObject = formattingObject;
			this.errorCode = errorCode;
		}

		public ErrorCodeException(ErrorCode errorCode,
			string message,
			Exception inner,
			object formattingObject = null)
			: base(message, inner)
		{
			this.errorCode = errorCode;
			this.formattingObject = formattingObject;
		}

		public ErrorCodeException(ErrorCode errorCode, string message, object formattingObject = null) : base(message)
		{
			this.errorCode = errorCode;
			this.formattingObject = formattingObject;
		}

		public ErrorCodeException(ErrorCode errorCode, Exception inner, object formattingObject = null)
			: this(errorCode, errorCode.ToString(), inner, formattingObject)
		{
		}

		public ErrorCode ErrorCode
		{
			get
			{
				return this.errorCode;
			}
		}

		public object FormattingObject
		{
			get
			{
				return this.formattingObject;
			}
		}

		public Guid InstanceIdentifier
		{
			get
			{
				return this.instanceIdentifier;
			}
		}
	}
}