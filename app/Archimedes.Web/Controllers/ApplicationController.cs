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
			var commandLocator = Bootstrapper.BootedKernel.ServiceLocater.GetService<ICommandLocator>();
			var logger = Bootstrapper.BootedKernel.ServiceLocater.GetService<ILogger>();
			BaseCommand<TRequest, TResult> command = null;
			
			try
			{
				command = commandLocator.FindCommand<TRequest, TResult>();
				var result = command.Execute(request);

				if (result.Success)
				{
					logger.Info("Successfully Processed Request", new { request, result });
					ajaxResult = new AjaxSuccessfulResult(result);
				}
				else
				{
					logger.Error("Error Processing Request", new { request, result });
					ajaxResult = new AjaxErrorResult(result.ErrorMessage, result);
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