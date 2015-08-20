namespace Archimedes.Common
{
	using Commands;
	using Exceptions;
	using Logging;
	using Mapping;
	using Settings;
	using Validation;

	using Ninject.Modules;
    
	public class CommonNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<ITypeConverter>().To<TypeConverter>();
			this.Bind<ISettings>().To<ReflectiveSettings>();
			this.Bind<ICommandLocator>().To<CommandLocator>();
			this.Bind<IMappingService>().To<AutoMapperMappingService>();
			this.Bind<IValidateThings>().To<ValidateThings>();
			this.Bind<ILogger>().To<NLogLogger>();
		    this.Bind<IErrorCodeMessageBuilder>().To<ErrorCodeMessageBuilder>();
		}
	}
}