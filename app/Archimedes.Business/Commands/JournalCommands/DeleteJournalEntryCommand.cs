namespace Archimedes.Business.Commands.JournalCommands
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using FluentValidation;

	public class DeleteJournalEntryCommand : AuthorizedBusinessCommand<DeleteJournalEntryRequest, bool>
	{
		public DeleteJournalEntryCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		protected override bool Work()
		{
			this.DataStore.JournalEntries.Delete(this.Request.JournalEntryId);
			return true;
		}

		protected override bool Authorize()
		{
			var journalEntry = this.DataStore.JournalEntries.Get(this.Request.JournalEntryId);
			return journalEntry.Userid == this.Request.RequestingUserId;
		}
	}

	public class DeleteJournalEntryRequest : AuthorizedRequest
	{
		public int JournalEntryId { get; set; }
	}

	public class DeleteJournalEntryRequestValidator : BaseValidator<DeleteJournalEntryRequest>
	{
		public DeleteJournalEntryRequestValidator(IMappingService mapper)
			: base(mapper)
		{
			RuleFor(req => req.RequestingUserId).GreaterThan(0);
			RuleFor(req => req.JournalEntryId).GreaterThan(0);
		}
	}
}
