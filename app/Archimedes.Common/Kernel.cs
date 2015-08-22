namespace Archimedes.Common
{
	using System;
	using System.Diagnostics;
	using Mapping;
	using ServiceLocater;

	public class Kernel
	{
		private static readonly object bootLock = new object();
		private static Kernel bootedKernel;

		private Kernel()
		{
		}

		public static void Boot(BootConfiguration configuration)
		{
			lock (bootLock)
			{
				if (bootedKernel == null)
				{
					bootedKernel = new Kernel();
					bootedKernel.Configuration = configuration;
					bootedKernel.WriteIfVerbose("Booting...");
					bootedKernel.ServiceLocatorInstance = new NinjectServiceLocator(configuration.Modules);
					bootedKernel.WriteIfVerbose("Loaded Ninject Modules");
					MappingConfigurationLoader.LoadConfigurations();
					bootedKernel.WriteIfVerbose("Configured Object Mappings");
					if (configuration.CheckServices)
					{
						bootedKernel.CheckServices();
						bootedKernel.WriteIfVerbose("Services Checked out");
					}

					bootedKernel.WriteIfVerbose("Boot Complete.");
				}
			}
		}

		public static IServiceLocator ServiceLocator => bootedKernel.ServiceLocatorInstance;

		public IServiceLocator ServiceLocatorInstance { get; private set; }
		public BootConfiguration Configuration { get; private set; }

		private void WriteIfVerbose(string format, params object[] args)
		{
			if (this.Configuration.Verbose)
			{
				Console.WriteLine(format, args);
			}
		}

		private void CheckServices()
		{
			this.Configuration.ServicesToCheck.ForEach(service =>
			{
				this.WriteIfVerbose("Checking {0}", service);
				var serviceInstance = ServiceLocator.GetService(service);
				Debug.Assert(serviceInstance != null);
				this.WriteIfVerbose("{0} service available as {1}", service, serviceInstance.GetType());
			});
		}
	}
}