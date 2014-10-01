namespace Archimedes.Business.Commands.JournalCommands
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using FluentValidation;

	/// <summary>
	/// The get user entries request validator.
	/// </summary>
	public class GetUserEntriesRequestValidator : BaseValidator<GetUserEntriesRequest>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetUserEntriesRequestValidator"/> class.
		/// </summary>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		public GetUserEntriesRequestValidator(IMappingService mapper)
			: base(mapper)
		{
			RuleFor(req => req.UserId).GreaterThan(0);
		}
	}
}
