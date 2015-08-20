namespace Archimedes.Common
{
	using Archimedes.Common.Exceptions;
	using Archimedes.Common.Mapping;

	public static class Bootstrapper
	{
		private static IKernel bootedKernel;

		public static bool HasBooted
		{
			get
			{
				return bootedKernel == null;
			}
		}

		public static IKernel BootedKernel
		{
			get
			{
				if (bootedKernel == null)
				{
					throw new ArchimedesException("You cannot access the pancake kernel without first booting it.");
				}

				return bootedKernel;
			}

			private set
			{
				bootedKernel = value;
			}
		}

		public static void Boot(BootConfiguration configuration)
		{
			if (bootedKernel == null)
			{
				var kernel = new Kernel(configuration);
				BootedKernel = kernel;
				MappingConfigurationLoader.LoadConfigurations();
			}
		}
	}
}