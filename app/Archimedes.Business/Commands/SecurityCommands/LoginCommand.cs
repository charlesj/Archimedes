namespace Archimedes.Business.Commands.SecurityCommands
{
	public class LoginCommand : BusinessCommand<LoginRequest, bool>
	{
		public LoginCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		protected override bool Work()
		{
			return this.DataStore.Users.Validate(this.Request.Username, this.Request.Password);
		}
	}
}
