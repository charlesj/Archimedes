namespace Archimedes.Common.Exceptions
{
    using System;

    /// <summary>
    /// This exception combines with the error codes so that we retain the full benefit of exception handling while
    /// keeping the ability to have individually identifiable errors with localizable strings for our users.
    /// </summary>
    public class ErrorCodeException : Exception
    {
        /// <summary>
        /// The error code.
        /// </summary>
        private readonly ErrorCode errorCode;

        /// <summary>
        /// The instance identifier.
        /// </summary>
        private readonly Guid instanceIdentifier = Guid.NewGuid();

        /// <summary>
        /// The formatting object.
        /// </summary>
        private readonly object formattingObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCodeException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="formattingObject">
        /// The formatting Object. Data that can be included in the user message can be set here.
        /// </param>
        public ErrorCodeException(ErrorCode errorCode, object formattingObject = null)
            : base(errorCode.ToString())
        {
            this.formattingObject = formattingObject;
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCodeException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        /// <param name="formattingObject">
        /// The formatting Object. Data that can be included in the user message can be set here.
        /// </param>
        public ErrorCodeException(ErrorCode errorCode, string message, Exception inner, object formattingObject = null)
            : base(message, inner)
        {
            this.errorCode = errorCode;
            this.formattingObject = formattingObject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCodeException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="formattingObject">
        /// The formatting Object.  Data that can be included in the user message can be set here.
        /// </param>
        public ErrorCodeException(ErrorCode errorCode, string message, object formattingObject = null)
            : base(message)
        {
            this.errorCode = errorCode;
            this.formattingObject = formattingObject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCodeException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        /// <param name="formattingObject">
        /// The formatting object.
        /// </param>
        public ErrorCodeException(ErrorCode errorCode, Exception inner, object formattingObject = null)
            : this(errorCode, errorCode.ToString(), inner, formattingObject)
        {
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public ErrorCode ErrorCode
        {
            get
            {
                return this.errorCode;
            }
        }

        /// <summary>
        /// Gets the formatting object.
        /// </summary>
        public object FormattingObject
        {
            get
            {
                return this.formattingObject;
            }
        }

        /// <summary>
        /// Gets the instance identifier.
        /// </summary>
        public Guid InstanceIdentifier
        {
            get
            {
                return this.instanceIdentifier;
            }
        }
    }
}
