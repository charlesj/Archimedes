namespace Archimedes.Common
{
	using ErrorCodes;
	using Exceptions;
	using Mapping;

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
					throw new ErrorCodeException(CommonErrors.CannotAccessKernelWithoutBooting);
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