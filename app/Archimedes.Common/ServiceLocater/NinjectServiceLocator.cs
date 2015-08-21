namespace Archimedes.Common.ServiceLocater
{
	using System;
	using System.Collections.Generic;
	using System.Linq;


	using Ninject;
	using Ninject.Modules;
	
	public class NinjectServiceLocator : IServiceLocator
	{
		private readonly IKernel kernel;

		public NinjectServiceLocator(IEnumerable<INinjectModule> modules)
		{
			this.kernel = new StandardKernel();
			if (modules.Any())
			{
				this.kernel.Load(modules);
			}
			else
			{
				this.kernel.Load("*.dll");
			}
		}

		public IKernel Kernel
		{
			get
			{
				return this.kernel; 
			}
		}

		public object GetService(Type type)
		{
			return this.kernel.Get(type);
		}

		public TServiceType GetService<TServiceType>()
		{
			return this.kernel.Get<TServiceType>();
		}
	}
}