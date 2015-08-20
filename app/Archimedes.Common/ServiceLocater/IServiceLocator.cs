namespace Archimedes.Common.ServiceLocater
{
	using System;

	public interface IServiceLocator 
	{
		object GetService(Type type);

		TServiceType GetService<TServiceType>();
	}
}