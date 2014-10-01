namespace Archimedes.Web.Controllers
{
	using System.Web.Mvc;

	using Archimedes.Web.Results;

	/// <summary>
	/// The security controller handles all security related activity, mainly login and logout.
	/// </summary>
	public class SecurityController : Controller
	{
		public ViewResult Login()
		{
			return this.View();
		}

		[HttpPost]
		public AjaxResult LoginPost(string username, string password)
		{
			return new AjaxSuccessfulResult(null);
		}

		[HttpPost]
		public AjaxResult LogOut()
		{
			return new AjaxSuccessfulResult(null);
		}
	}
}