namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using Archimedes.Common.Commands;

	/// <summary>
	/// The create manuscript request.
	/// </summary>
	public class CreateManuscriptRequest : UnauthorizedRequest
	{
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }
	}
}