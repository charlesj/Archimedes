namespace Archimedes.Common
{
	using System;
	using System.ComponentModel;

	using Exceptions;
	using ErrorCodes;

	public class TypeConverter : ITypeConverter
	{
		public object Convert(object value, Type targetType)
		{
			var converter = TypeDescriptor.GetConverter(targetType);
			if (!converter.IsValid(value) || !converter.CanConvertFrom(value.GetType()))
			{
				throw new ErrorCodeException(CommonErrors.TypeConversionToInvalidType, new { targetType, value });
			}

			if (value is string)
			{
				return converter.ConvertFromString(value as string);
			}

			return converter.ConvertTo(value, targetType);
		}

		public TTargetType Convert<TTargetType>(object value)
		{
			return (TTargetType)this.Convert(value, typeof(TTargetType));
		}
	}
}