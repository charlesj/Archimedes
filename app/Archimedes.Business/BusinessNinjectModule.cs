namespace Archimedes.Business
{
	using System.Collections.Generic;

	using Commands;
	using Common.Commands;
	using Common.Validation;
	using Data.Models;

	using Ninject.Modules;

	public class BusinessNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IBusinessServices>().To<BusinessServices>();

			this.RegisterCommand<AddRuleRequest, Rule, AddRuleCommand, AddRuleRequestValidator>();
			this.RegisterCommand<GetRulesRequest, List<Rule>, GetRulesCommand, GetRulesRequestValidator>();
		}

		private void RegisterCommand<TRequest, TResult, TCommand, TRequestValidator>() 
			where TRequest : Request
			where TCommand : BaseCommand<TRequest, TResult>
			where TRequestValidator : IValidate<TRequest>
		{
			this.Bind<BaseCommand<TRequest, TResult>>().To<TCommand>();
			this.Bind<IValidate<TRequest>>().To<TRequestValidator>();
		}
	}
}