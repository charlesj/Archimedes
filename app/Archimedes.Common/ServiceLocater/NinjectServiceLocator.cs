namespace Archimedes.Common.ServiceLocater
{
	using System;
	using System.Linq;

	using Ninject;
	
	public class NinjectServiceLocator : IServiceLocator
	{
		private readonly IKernel kernel;

		public NinjectServiceLocator(params string[] assemblySearchPatterns)
		{
			this.kernel = new StandardKernel();
			if (assemblySearchPatterns.Any())
			{
				foreach (var pattern in assemblySearchPatterns)
				{
					this.kernel.Load(pattern);
				}
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