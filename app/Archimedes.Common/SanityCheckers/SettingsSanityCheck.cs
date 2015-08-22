namespace Archimedes.Common.SanityCheckers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Settings;

	public class SettingsSanityCheck : ICheckKernelSanity
	{
		public void Check(Kernel kernel)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var settingsInterfaces = new List<Type>();
			foreach (var assembly in assemblies)
			{
				settingsInterfaces.AddRange(assembly.GetTypes().Where(type => type.IsInterface && type.IsAssignableFrom(typeof(ISettings))));
			}

			foreach (var settingsInterface in settingsInterfaces)
			{
				var settings = (ISettings)kernel.ServiceLocatorInstance.GetService(settingsInterface);
				settings.CheckAllSettingForValues();
			}
			// kernel.WriteIfVerbose("Settings implementations seem to be sane.");
		}
	}
}