namespace Archimedes.Business.Commands.JournalCommands
{
	using Archimedes.Common.Commands;

	public class GetUserEntriesRequest : UnauthorizedRequest
	{
		public int UserId { get; set; }
	}
}