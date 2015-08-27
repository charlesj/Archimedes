using Archimedes.Data.Models;

namespace Archimedes.Web.Controllers
{
	using System.Web.Mvc;
	using Business.Commands;
	using Common.Commands;

	public class ArtifactsController : Controller
    {
		private readonly CommandProcessor processor;

		public ArtifactsController(CommandProcessor processor)
		{
			this.processor = processor;
		}

		[HttpGet]
		public ActionResult Index(int startIndex = 0)
        {
            var request = new GetPagedArtifactsRequest { StartIndex = startIndex, PageSize = 5 };
			var response = this.processor.Process<GetPagedArtifactsRequest, GetPagedArtifactsResponse> (request);
			switch (response.ResultType)
			{
				case ResponseTypes.Success:
					return this.View(response.Result);
				default:
					return new HttpStatusCodeResult(503);
			}
        }

		[HttpGet]
		public ActionResult AddForm()
		{
			return this.View();
		}

		[HttpPost]
		public ActionResult Add(string title, string description, string link)
		{
			var request = new AddArtifactRequest {Title = title, Description = description, Link = link};
			var response = this.processor.Process<AddArtifactRequest, Artifact>(request);
			switch (response.ResultType)
			{
				case ResponseTypes.Success:
					return this.RedirectToAction("Index");
				default:
					return new HttpStatusCodeResult(503);
			}
		}
    }
}