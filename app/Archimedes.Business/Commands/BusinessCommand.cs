namespace Archimedes.Business.Commands
{
	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Contracts;

	public abstract class BusinessCommand<TRequest, TResult> : BaseCommand<TRequest, TResult> where TRequest : Request
	{
		private readonly IBusinessServices businessServices;

		protected BusinessCommand(IBusinessServices businessServices)
			: base(businessServices.Validator)
		{
			this.businessServices = businessServices;
		}

		protected IMappingService Mapper => this.businessServices.Mapper;

		protected IValidateThings Validator => this.businessServices.Validator;

		protected IDataStorage DataStore => this.businessServices.DataStore;
	}
}