namespace Archimedes.Common
{
	using System;
	using System.ComponentModel;

	using Exceptions;

	public class TypeConverter : ITypeConverter
	{
		public object Convert(object value, Type targetType)
		{
			var converter = TypeDescriptor.GetConverter(targetType);
			if (!converter.IsValid(value) || !converter.CanConvertFrom(value.GetType()))
			{
				throw new ArchimedesException("Attempted to convert to a type that was not valid.", new { targetType, value });
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
