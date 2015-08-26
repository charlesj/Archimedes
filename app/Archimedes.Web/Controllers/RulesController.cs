using System.Collections.Generic;
using Archimedes.Business.Commands;
using Archimedes.Common.Commands;
using Archimedes.Data.Models;

namespace Archimedes.Web.Controllers
{
	using System.Web.Mvc;

	public class RulesController : Controller
    {
		private readonly CommandProcessor processor;

		public RulesController(CommandProcessor processor)
		{
			this.processor = processor;
		}

		public ActionResult Index()
        {
            var request = new GetRulesRequest { StartIndex = 0, PageSize = 10 };
			var response = this.processor.Process<GetRulesRequest, GetRulesResponse> (request);
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