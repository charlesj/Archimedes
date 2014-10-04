namespace Archimedes.Business.Commands
{
	using Archimedes.Common.Commands;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;
	using Archimedes.Data.Contracts;

	/// <summary>
	/// The business command.
	/// </summary>
	/// <typeparam name="TRequest">
	/// The Type of the request
	/// </typeparam>
	/// <typeparam name="TResult">
	/// The Type of the result
	/// </typeparam>
	public abstract class AuthorizedBusinessCommand<TRequest, TResult> : BaseCommand<TRequest, TResult> where TRequest : AuthorizedRequest
	{
		private readonly IBusinessServices businessServices;

		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessCommand{TRequest,TResult}"/> class.
		/// </summary>
		/// <param name="businessServices">
		/// The business Services.
		/// </param>
		protected AuthorizedBusinessCommand(IBusinessServices businessServices)
			: base(businessServices.Validator)
		{
			this.businessServices = businessServices;
		}

		/// <summary>
		/// Gets or sets the mapper.
		/// </summary>
		protected IMappingService Mapper
		{
			get
			{
				return this.businessServices.Mapper;
			}
		}

		/// <summary>
		/// Gets or sets the validator.
		/// </summary>
		protected IValidateThings Validator
		{
			get
			{
				return this.businessServices.Validator;
			}
		}

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		protected IDataStorage DataStore
		{
			get
			{
				return this.businessServices.DataStore;
			}
		}
	}

	public abstract class BusinessCommand<TRequest, TResult> : AuthorizedBusinessCommand<TRequest, TResult> where TRequest : UnauthorizedRequest
	{
		protected BusinessCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		protected override bool Authorize()
		{
			// This command doesn't require specific authorization.
			return true;
		}
	}
}