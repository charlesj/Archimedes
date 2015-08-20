namespace Archimedes.Common
{
	using System;
    
	public interface ITypeConverter
	{
		object Convert(object value, Type targetType);
		TTargetType Convert<TTargetType>(object value);
	}
}