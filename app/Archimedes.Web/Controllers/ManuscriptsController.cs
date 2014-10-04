namespace Archimedes.Web.Controllers
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Web.Mvc;

	using Archimedes.Business.BusinessObjects;
	using Archimedes.Business.Commands.ManuscriptCommands;
	using Archimedes.Web.Results;

	/// <summary>
	/// The manuscripts controller.
	/// </summary>
	public class ManuscriptsController : ApplicationController
    {
		/// <summary>
		/// The get all.
		/// </summary>
		/// <returns>
		/// The <see cref="AjaxResult"/>.
		/// </returns>
		[HttpGet]
		public AjaxResult GetAll()
		{
			var request = new GetAllManuscriptsRequest();
			return this.ProcessRequest<GetAllManuscriptsRequest, List<Manuscript>>(request);
		}

		/// <summary>
		/// The create.
		/// </summary>
		/// <param name="title">
		/// The title.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <returns>
		/// The <see cref="AjaxResult"/>.
		/// </returns>
		[HttpPost]
		public AjaxResult Create(string title, string description)
		{
			var request = new CreateManuscriptRequest { Description = description, Title = title };
			return this.ProcessRequest<CreateManuscriptRequest, Manuscript>(request);
		}

    }
}
