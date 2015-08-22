namespace Archimedes.Web.Controllers
{
	using System;
	using System.Web.Mvc;
	using Common;
	using Common.Commands;
	using Common.Logging;
	using Results;

	public abstract class ApplicationController : Controller
    {
		protected AjaxResult ProcessRequest<TRequest, TResult>(TRequest request) where TRequest : Request
		{
			AjaxResult ajaxResult;
			var commandLocator = Kernel.ServiceLocator.GetService<ICommandLocator>();
			var logger = Kernel.ServiceLocator.GetService<ILogger>();
			BaseCommand<TRequest, TResult> command = null;
			
			try
			{
				command = commandLocator.FindCommand<TRequest, TResult>();
				var result = command.Execute(request);

				switch (result.ResultType)
				{
					case ResponseTypes.Success:
						logger.Info("Successfully Processed Request", new { request, result });
						ajaxResult = new AjaxSuccessfulResult(result);
						break;
					case ResponseTypes.Error:
						logger.Error("Error Processing Request", new { request, result });
						ajaxResult = new AjaxErrorResult("HEY REDO THIS", result);
						break;
					case ResponseTypes.InvalidRequest:
						logger.Error("Invalid Request", new { request, result });
						ajaxResult = new AjaxErrorResult("HEY REDO THIS", result);
						break;
					case ResponseTypes.Unauthorized:
						logger.Error("Unauthorized Request", new { request, result });
						ajaxResult = new AjaxErrorResult("HEY REDO THIS", result);
						break;
					default:
						ajaxResult = new AjaxErrorResult("Unknown response type", result);
						break;
				}
			}
			catch (Exception exception)
			{
				logger.Error("Could not process request", new { request, exception, command });
				ajaxResult = new AjaxErrorResult("Could not process request", new { request, exception });
			}

			return ajaxResult;
		}
    }
}