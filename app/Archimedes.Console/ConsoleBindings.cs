using Archimedes.Common.Validation;

namespace Archimedes.Console
{
	using Common.Commands;
	using Commands;
	
	using Ninject.Modules;

	public class ConsoleNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<BaseCommand<NullRequest, bool>>().To<NullCommand>();
			this.Bind<IValidate<NullRequest>>().To<NullRequestValidator>();
		}
	}
}