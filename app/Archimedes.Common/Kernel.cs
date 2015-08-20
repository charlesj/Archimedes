namespace Archimedes.Common
{
	using System;

	using ServiceLocater;

	// TODO: Implement Singleton Correctly.
	public class Kernel : IKernel
	{
		private readonly BootConfiguration configuration;

		public Kernel(BootConfiguration configuration)
		{
			this.configuration = configuration;
			this.WriteIfVerbose("Booting...");

			this.ServiceLocator = new NinjectServiceLocator(configuration.AssemblySearchPatterns.ToArray());

			if (this.configuration.CheckSanity)
			{
				this.CheckSanity();
			}
			
			this.WriteIfVerbose("Boot Complete.");
		}

		public IServiceLocator ServiceLocator { get; private set; }

		public void CheckSanity()
		{
			this.WriteIfVerbose("Checking Sanity");
			//this.CheckSanityOfSettingsObjects();
			this.WriteIfVerbose("Hey it's sane!");
		}

		public void WriteIfVerbose(string format, params object[] args)
		{
			if (this.configuration.Verbose)
			{
				Console.WriteLine(format, args);
			}
		}
	}
}
