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
			this.ServicesToCheck = new List<Type>
										{
											typeof (ISettings),
											typeof (ILogger),
											typeof (ITypeConverter),
											typeof (IMappingService),
											typeof (IValidateThings)
										};
			this.CheckServices = true;
			this.Verbose = false;
		}

		public static BootConfiguration DefaultConfiguration
		{
			get
			{
				return new BootConfiguration();
			}
		}

		public List<INinjectModule> Modules { get; }
		public List<Type> ServicesToCheck { get; }

		public bool CheckServices { get; set; }

		public bool Verbose { get; set; }

		public void AddServiceToCheck(Type serviceType)
		{
			if (!this.ServicesToCheck.Contains(serviceType))
			{
				this.ServicesToCheck.Add(serviceType);
			}
		}

		public BootConfiguration SkipServicesCheck()
		{
			this.CheckServices = false;
			return this;
		}

		public BootConfiguration AddNinjectModule(INinjectModule module)
		{
			this.Modules.Add(module);
			return this;
		}

		public BootConfiguration BeVerbose()
		{
			this.Verbose = true;
			return this;
		}
	}
}