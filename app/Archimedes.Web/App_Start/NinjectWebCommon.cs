[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Archimedes.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Archimedes.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Archimedes.Web.App_Start
{
    using System;
    using System.Web;

    using Archimedes.Common;
    using Archimedes.Common.ServiceLocater;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web.Common;

    using Bootstrapper = Ninject.Web.Common.Bootstrapper;
    using IKernel = Ninject.IKernel;

	public static class NinjectWebCommon 
    {
	    /// <summary>
	    /// The bootstrapper.
	    /// </summary>
	    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
		
		/// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
			Common.Bootstrapper.Boot(BootConfiguration.DefaultConfiguration.AddAssemblySearchPattern("Archimedes*.dll"));
			var kernel = ((NinjectServiceLocator)Common.Bootstrapper.BootedKernel.ServiceLocator).Kernel;
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }      
    }
}
