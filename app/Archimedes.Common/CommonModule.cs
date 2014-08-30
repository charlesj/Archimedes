namespace Archimedes.Common
{
	using Archimedes.Common.Settings;

	using Ninject.Modules;

	/// <summary>
	/// The pancakes ninject module.  Contains the bindings for the internal interfaces.
	/// </summary>
	public class PancakesNinjectModule : NinjectModule
	{
		/// <summary>
		/// Binds the internal pancakes types to their implementations.
		/// </summary>
		public override void Load()
		{
			this.Bind<ITypeConverter>().To<TypeConverter>();
			this.Bind<ISettings>().To<ReflectiveSettings>();
		}
	}
}