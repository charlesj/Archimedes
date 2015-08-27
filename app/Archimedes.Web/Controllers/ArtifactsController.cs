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

		public ActionResult Index()
        {
            var request = new GetArtifactsRequest { StartIndex = 0, PageSize = 10 };
			var response = this.processor.Process<GetArtifactsRequest, GetArtifactsResponse> (request);
			switch (response.ResultType)
			{
				case ResponseTypes.Success:
					return this.View(response.Result);
				default:
					return new HttpStatusCodeResult(503);
			}
        }	
    }
}