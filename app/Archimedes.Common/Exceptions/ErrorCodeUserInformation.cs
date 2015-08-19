namespace Archimedes.Common.Exceptions
{
    /// <summary>
    /// The error code user information.  This is the pieces of information that will be available to end users.
    /// </summary>
    public class ErrorCodeUserInformation
    {
        /// <summary>
        /// Gets or sets the full code (i.e. FullIdentifier).  Example: "COMMON101"
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the instance.  This is the GUID as a string.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Gets or sets the message that will be displayed to the user.
        /// </summary>
        public string Message { get; set; }
    }
}