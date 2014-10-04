namespace Archimedes.Business.Commands.JournalCommands
{
	using System;

	using Archimedes.Common.Commands;

	/// <summary>
	/// The add journal entry request.
	/// </summary>
	public class AddJournalEntryRequest : UnauthorizedRequest
	{
		public int UserId { get; set; }

		public DateTime EntryDate { get; set; }

		public string Content { get; set; }
	}
}
