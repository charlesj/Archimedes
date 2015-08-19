namespace Archimedes.Common.ErrorCodes
{
    using Archimedes.Common.Exceptions;

    public class CommonErrors : ErrorCode
    {
        public static ErrorCode MissingApplicationConfiguration = new CommonErrors(100, "Something missing from app.config");
        public static ErrorCode CouldNotLocateCommand = new CommonErrors(101, "Could not find the requested command");

        protected CommonErrors(int identifier, string shortDescription)
            : base("COMMON", identifier, shortDescription)
        {
        }
    }
}