namespace Archimedes.Business.Mappings
{
	using Archimedes.Business.BusinessObjects;
	using Archimedes.Business.Commands.JournalCommands;
	using Archimedes.Common.Mapping;

	using AutoMapper;

	/// <summary>
	/// The journal entry mappings.
	/// </summary>
	public class JournalEntryMappings : IMappingConfiguration
	{
		public void Configure()
		{
			// To business object  mappings.
			Mapper.CreateMap<Data.Models.JournalEntry, JournalEntry>();

			// To Data Model Mappings
			Mapper.CreateMap<AddJournalEntryRequest, Data.Models.JournalEntry>();
		}
	}
}
