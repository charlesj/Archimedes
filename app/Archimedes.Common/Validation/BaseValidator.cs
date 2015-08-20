namespace Archimedes.Common.Validation
{
	using Mapping;

	using FluentValidation;
	using FluentValidation.Results;

	public abstract class BaseValidator<T> : AbstractValidator<T>, IValidate<T>
	{
		protected BaseValidator(IMappingService mapper)
		{
			this.Mapper = mapper;
		}

		protected IMappingService Mapper { get; set; }

		public Result Check(T validationTarget)
		{
			var result = this.Validate(validationTarget);
			return this.Mapper.Map<ValidationResult, Result>(result);
		}
	}
}