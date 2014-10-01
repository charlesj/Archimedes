namespace Archimedes.Business.Commands.JournalCommands
{
	using System.Collections.Generic;

	using Archimedes.Business.BusinessObjects;

	/// <summary>
	/// Gets the Journal Entries for an individual user.
	/// </summary>
	public class GetUserEntriesCommand : BusinessCommand<GetUserEntriesRequest, List<JournalEntry>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetUserEntriesCommand"/> class.
		/// </summary>
		/// <param name="businessServices">
		/// The business services.
		/// </param>
		public GetUserEntriesCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		/// <summary>
		/// The work.
		/// </summary>
		/// <returns>
		/// The <see cref="List"/>.
		/// </returns>
		protected override List<JournalEntry> Work()
		{
			var entries = this.DataStore.JournalEntries.GetUsersEntries(this.Request.UserId);
			var mapped = this.Mapper.Map<IEnumerable<Data.Models.JournalEntry>, List<JournalEntry>>(entries);
			return mapped;
		}
	}
}
