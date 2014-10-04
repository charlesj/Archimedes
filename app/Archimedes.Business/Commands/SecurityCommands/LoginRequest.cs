namespace Archimedes.Business.Commands.SecurityCommands
{
	using Archimedes.Common.Commands;

	/// <summary>
	/// The login request.
	/// </summary>
	public class LoginRequest : UnauthorizedRequest
	{
		public string Username { get; set; }

		public string Password { get; set; }
	}
}
