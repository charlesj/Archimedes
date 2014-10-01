namespace Archimedes.Business.Commands.JournalCommands
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using FluentValidation;

	/// <summary>
	/// The add journal entry request validator.
	/// </summary>
	public class AddJournalEntryRequestValidator : BaseValidator<AddJournalEntryRequest>
	{
		public AddJournalEntryRequestValidator(IMappingService mapper)
			: base(mapper)
		{
			this.RuleFor(req => req.UserId).GreaterThan(0);
			this.RuleFor(req => req.EntryDate).NotNull();
			this.RuleFor(req => req.Content).NotNull().NotEmpty();
		}
	}
}