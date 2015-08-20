namespace Archimedes.Common.Settings
{
	using System;

	using Exceptions;
	using Extensions;

	public class ReflectiveSettings : Settings
	{
		public ReflectiveSettings(ITypeConverter typeConverter) : base(typeConverter)
		{
			this.LoadSettingsUsingReflection();
		}

		protected void LoadSettingsUsingReflection()
		{
			var properties = this.GetProperties();
			foreach (var property in properties)
			{
				try
				{
					var settingsValue = this.GetValue(property.Name);
					var propertyType = property.PropertyType;
					var typedValue = this.TypeConverter.Convert(settingsValue, propertyType);
					property.SetValue(this, typedValue);
				}
				catch (Exception exception)
				{
					string message = string.Format("Error trying to set a value for {0} from application configuration.  See inner exception for more details.", property.Name);
					throw new ArchimedesException(message, exception);
				}
			}
		}
	}
}