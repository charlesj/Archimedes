namespace Archimedes.Business.Commands.JournalCommands
{
	using Archimedes.Common.Commands;

	public class GetUserEntriesRequest : Request
	{
		public int UserId { get; set; }
	}
}