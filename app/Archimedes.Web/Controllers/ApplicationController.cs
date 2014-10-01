namespace Archimedes.Web.Controllers
{
	using System;
	using System.Web.Mvc;

	using Archimedes.Common;
	using Archimedes.Common.Commands;
	using Archimedes.Common.Logging;
	using Archimedes.Web.Results;

	public abstract class ApplicationController : Controller
    {
		protected AjaxResult ProcessRequest<TRequest, TResult>(TRequest request) where TRequest : Request
		{
			AjaxResult ajaxResult;
			var commandLocator = Bootstrapper.BootedKernel.ServiceLocator.GetService<ICommandLocator>();
			var logger = Bootstrapper.BootedKernel.ServiceLocator.GetService<ILogger>();
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
					case ResponseTypes.InvalidRequest:
					case ResponseTypes.Unauthorized:
						logger.Error("Error Processing Request", new { request, result });
						ajaxResult = new AjaxErrorResult(result.ErrorMessage, result);
						break;
					default:
						ajaxResult = new AjaxErrorResult("Unknown response type", result);
						break;
				}
			}
			catch (Exception exception)
			{
				logger.Error("Could not process request", new { request, exception, command });
				ajaxResult = new AjaxErrorResult("Could not process request", new { request });
			}

			return ajaxResult;
		}
    }
}