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
	public abstract class BusinessCommand<TRequest, TResult> : BaseCommand<TRequest, TResult> where TRequest : Request
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessCommand{TRequest,TResult}"/> class.
		/// </summary>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		/// <param name="validator">
		/// The validator.
		/// </param>
		/// <param name="data">
		/// The data.
		/// </param>
		protected BusinessCommand(IMappingService mapper, IValidateThings validator, IDataStorage data)
		{
			this.Mapper = mapper;
			this.Validator = validator;
			this.Data = data;
		}

		/// <summary>
		/// Gets or sets the mapper.
		/// </summary>
		protected IMappingService Mapper { get; set; }

		/// <summary>
		/// Gets or sets the validator.
		/// </summary>
		protected IValidateThings Validator { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		protected IDataStorage Data { get; set; }
	}
}