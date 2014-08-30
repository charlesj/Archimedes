namespace Archimedes.Common
{
	using Archimedes.Common.Commands;
	using Archimedes.Common.Logging;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Settings;
	using Archimedes.Common.Validation;

	using Ninject.Modules;

	/// <summary>
	/// The pancakes ninject module.  Contains the bindings for the internal interfaces.
	/// </summary>
	public class CommonNinjectModule : NinjectModule
	{
		/// <summary>
		/// Binds the internal pancakes types to their implementations.
		/// </summary>
		public override void Load()
		{
			this.Bind<ITypeConverter>().To<TypeConverter>();
			this.Bind<ISettings>().To<ReflectiveSettings>();
			this.Bind<ICommandLocator>().To<CommandLocator>();
			this.Bind<IMappingService>().To<AutoMapperMappingService>();
			this.Bind<IValidateThings>().To<ValidateThings>();
			this.Bind<ILogger>().To<NLogLogger>();
		}
	}
}