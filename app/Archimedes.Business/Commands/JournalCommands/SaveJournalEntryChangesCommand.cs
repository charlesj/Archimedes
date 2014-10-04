namespace Archimedes.Business.Commands.JournalCommands
{
	using System;

	using Archimedes.Business.BusinessObjects;
	using Archimedes.Business.Commands;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using AutoMapper;

	using FluentValidation;

	public class SaveJournalEntryChangesCommand : AuthorizedBusinessCommand<SaveJournalEntryChangesRequest, JournalEntry>
	{
		public SaveJournalEntryChangesCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		protected override JournalEntry Work()
		{
			var updatedEntry = this.Mapper.Map<SaveJournalEntryChangesRequest, Data.Models.JournalEntry>(this.Request);
			updatedEntry = this.DataStore.JournalEntries.Update(updatedEntry);
			var mapped = this.Mapper.Map<Data.Models.JournalEntry, JournalEntry>(updatedEntry);
			return mapped;
		}

		protected override bool Authorize()
		{
			var entry = this.DataStore.JournalEntries.Get(this.Request.JournalEntryId);
			return entry.Userid == this.Request.RequestingUserId;
		}
	}

	public class SaveJournalEntryChangesRequest : AuthorizedRequest
	{
		public int JournalEntryId { get; set; }

		public string Content { get; set; }

		public DateTime EntryDate { get; set; }
	}

	public class SaveJournalEntryChangesRequestMappings : IMappingConfiguration
	{
		public void Configure()
		{
			Mapper.CreateMap<SaveJournalEntryChangesRequest, Data.Models.JournalEntry>()
				.ForMember(dest => dest.Id, option => option.MapFrom(source => source.JournalEntryId))
				.ForMember(dest => dest.Userid, option => option.MapFrom(source => source.RequestingUserId));
		}
	}

	public class SaveJournalEntryChangesRequestValdiator : BaseValidator<SaveJournalEntryChangesRequest>
	{
		public SaveJournalEntryChangesRequestValdiator(IMappingService mapper)
			: base(mapper)
		{
			this.RuleFor(req => req.JournalEntryId).GreaterThan(0);
			this.RuleFor(req => req.EntryDate).NotEmpty();
			this.RuleFor(req => req.RequestingUserId).NotEmpty().GreaterThan(0);
			this.RuleFor(req => req.Content).NotEmpty();
		}
	}
}
