namespace Archimedes.Common.ErrorCodes
{
	using Exceptions;

	public class CommonErrors : ErrorCode
	{
		public static ErrorCode MissingApplicationConfiguration = new CommonErrors(100, "Something missing from app.config");
		public static ErrorCode CouldNotLocateCommand = new CommonErrors(101, "Could not find the requested command");
		public static ErrorCode CannotAccessKernelWithoutBooting = new CommonErrors(102, "Cannot access the kernel without booting");
		public static ErrorCode CouldNotSetSettingValue = new CommonErrors(103, "Could not set a value for the given key");
		public static ErrorCode TypeConversionToInvalidType = new CommonErrors(104, "A Type conversion was requested for an invalid type");
		public static ErrorCode SettingsValueNotPresentInConfig = new CommonErrors(105, "A value in the settings class was not present in the application configuration");
		public static ErrorCode SettingsFailedSanityCheck = new CommonErrors(106, "The settings could not pass the sanity check");

		protected CommonErrors(int identifier, string shortDescription)
			: base("COMMON", identifier, shortDescription)
		{}
	}
}