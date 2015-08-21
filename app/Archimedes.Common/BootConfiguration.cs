namespace Archimedes.Common
{
	using System.Collections.Generic;
	
	using Ninject.Modules;

	public class BootConfiguration
	{
		public BootConfiguration()
		{
			this.Modules = new List<INinjectModule>();
			this.CheckSanity = true;
			this.Verbose = false;
		}

		public static BootConfiguration DefaultConfiguration
		{
			get
			{
				return new BootConfiguration();
			}
		}

		public List<INinjectModule> Modules { get; set; }

		public bool CheckSanity { get; set; }

		public bool Verbose { get; set; }

		public BootConfiguration SkipSanityCheck()
		{
			this.CheckSanity = false;
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