namespace Archimedes.Web.Services
{
	using System.Web.Security;

	public class AuthenticationService
	{
		public void SignIn(string username)
		{
			FormsAuthentication.SetAuthCookie(username, true);
		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
}