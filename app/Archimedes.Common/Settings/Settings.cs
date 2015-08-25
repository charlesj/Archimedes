namespace Archimedes.Common.Settings
{
	using System.Configuration;

	using Exceptions;
	using Extensions;
	using ErrorCodes;

	public class Settings : ISettings
	{
		public Settings(ITypeConverter typeConverter)
		{
			this.TypeConverter = typeConverter;
			this.ApplicationName = this.GetValue("ApplicationName");
			this.ApplicationInstance = this.GetValue("ApplicationInstance");
		}

		public string ApplicationName { get; protected set; }

		public string ApplicationInstance { get; protected set; }

		protected ITypeConverter TypeConverter { get; private set; }

		public void CheckAllSettingForValues()
		{
			var properties = this.GetProperties();
			foreach (var property in properties)
			{
				var value = property.GetValue(this);
				if (value == null)
				{
					throw new ErrorCodeException(CommonErrors.SettingsFailedSanityCheck, new { property.Name });
				}
			}
		}

		protected string GetValue(string key)
		{
			var value = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrEmpty(value))
			{
				throw new ErrorCodeException(CommonErrors.SettingsValueNotPresentInConfig, new { key });
			}

			return value;
		}

		protected TSettingsType GetValue<TSettingsType>(string key)
		{
			return this.TypeConverter.Convert<TSettingsType>(this.GetValue(key));
		}
	}
}