namespace Archimedes.Business
{
	using Common.Commands;
	using Ninject.Modules;

	public class BusinessNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IBusinessServices>().To<BusinessServices>();
		}

		private void RegisterCommand<TRequest, TResult, TCommand>() where TRequest : Request
			where TCommand : BaseCommand<TRequest, TResult>
		{
			this.Bind<BaseCommand<TRequest, TResult>>().To<TCommand>();
		}
	}
}