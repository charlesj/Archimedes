namespace Archimedes.Common
{
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
					configuration.Out("Booting...");
					bootedKernel.ServiceLocatorInstance = new NinjectServiceLocator(configuration.Modules);
					configuration.Out("Loaded Ninject Modules");
					MappingConfigurationLoader.LoadConfigurations();
					configuration.Out("Configured Object Mappings");
					if (configuration.CheckServices)
					{
						bootedKernel.CheckServices();
					}

					configuration.Out("Boot Complete.");
				}
			}
		}

		public static IServiceLocator ServiceLocator => bootedKernel.ServiceLocatorInstance;

		public IServiceLocator ServiceLocatorInstance { get; private set; }
		public BootConfiguration Configuration { get; private set; }

		private void CheckServices()
		{
			this.Configuration.ServicesToCheck.ForEach(service =>
			{
				this.Configuration.Out("Checking {0}", service);
				var serviceInstance = ServiceLocator.GetService(service);
				Debug.Assert(serviceInstance != null);
				this.Configuration.Out("{0} service available as {1}", service, serviceInstance.GetType());
			});

			this.Configuration.Out("Services Checked out");
		}
	}
}