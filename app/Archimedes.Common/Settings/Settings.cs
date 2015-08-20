namespace Archimedes.Common.Settings
{
	using System.Configuration;

	using Exceptions;
	using Extensions;

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
					var message = string.Format("Settings property is missing value: {0}", property.Name);
					throw new ArchimedesException(message, this);
				}
			}
		}

		protected string GetValue(string key)
		{
			var value = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrEmpty(value))
			{
				string message = string.Format("Missing Settings Value: {0}", key);
				throw new ArchimedesException(message);
			}

			return value;
		}

		protected TSettingsType GetValue<TSettingsType>(string key)
		{
			return this.TypeConverter.Convert<TSettingsType>(this.GetValue(key));
		}
	}
}