namespace Archimedes.Common.ErrorCodes
{
    using Archimedes.Common.Exceptions;

    public class CommonErrors : ErrorCode
    {
        public static ErrorCode MissingApplicationConfiguration = new CommonErrors(100, "Something missing from app.config");

        protected CommonErrors(int identifier, string shortDescription)
            : base("COMMON", identifier, shortDescription)
        {
        }
    }
}