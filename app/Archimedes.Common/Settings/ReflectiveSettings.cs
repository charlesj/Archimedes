namespace Archimedes.Common.Settings
{
	using System;

	using Exceptions;
	using Extensions;
	using ErrorCodes;

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
					throw new ErrorCodeException(CommonErrors.CouldNotSetSettingValue, exception, new { property.Name });
				}
			}
		}
	}
}