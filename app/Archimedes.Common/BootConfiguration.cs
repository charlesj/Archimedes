namespace Archimedes.Common
{
	using System.Collections.Generic;
	using System;
	using Logging;
	using Mapping;
	using Settings;
	using Validation;
	using Ninject.Modules;

	public class BootConfiguration
	{
		public BootConfiguration()
		{
			this.Modules = new List<INinjectModule>();
			this.ServicesToCheck = new List<Type>();
		}

		public static BootConfiguration DefaultConfiguration
		{
			get
			{
				var config = new BootConfiguration
				{
					CheckServices = true,
					Verbose = false,
					VerboseOut = Console.WriteLine
				};

				config.ServicesToCheck.AddRange(new[] {
						typeof(ISettings),
						typeof(ILogger),
						typeof(ITypeConverter),
						typeof(IMappingService),
						typeof(IValidateThings)
                    });

				return config;
			}
		}

		public List<INinjectModule> Modules { get; set; }
		public List<Type> ServicesToCheck { get; set; }
		public bool CheckServices { get; set; }
		public bool Verbose { get; set; }
		public Action<string, object[]> VerboseOut { get; set; }

		public void Out(string format, params object[] args)
		{
			if (this.Verbose)
			{
				this.VerboseOut(format, args);
			}
		}
	}

	public static class BootConfigurationFluent
	{
		public static BootConfiguration SkipServicesCheck(this BootConfiguration configuration)
		{
			configuration.CheckServices = false;
			return configuration;
		}

		public static BootConfiguration AddServiceToCheck(this BootConfiguration configuration, Type serviceType)
		{
			if (!configuration.ServicesToCheck.Contains(serviceType))
			{
				configuration.ServicesToCheck.Add(serviceType);
			}

			return configuration;
		}

		public static BootConfiguration AddNinjectModule(this BootConfiguration configuration, INinjectModule module)
		{
			configuration.Modules.Add(module);
			return configuration;
		}

		public static BootConfiguration BeVerbose(this BootConfiguration configuration)
		{
			configuration.Verbose = true;
			return configuration;
		}

		public static BootConfiguration VerboseWith(this BootConfiguration configuration, Action<string, object[]> output)
		{
			configuration.VerboseOut = output;
			return configuration;
		}
	}
}