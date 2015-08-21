using Archimedes.Common.Extensions;

namespace Archimedes.Common.Commands
{
	using System;
	using Logging;

	public class CommandProcessor
	{
		private readonly ILogger logger;
		private readonly ICommandLocator commandLocator;

		public CommandProcessor(ILogger logger, ICommandLocator commandLocator)
		{
			this.logger = logger;
			this.commandLocator = commandLocator;
		}

		public Response<TResult> Process<TRequest, TResult>(TRequest request) where TRequest : Request
		{
			BaseCommand<TRequest, TResult> command = null;

			try
			{
				command = commandLocator.FindCommand<TRequest, TResult>();
				var result = command.Execute(request);
				var commandName = command.GetType().Name;

				switch (result.ResultType)
				{
					case ResponseTypes.Success:
						this.logger.Info("{commandName} Success".FormatWith(new { commandName }), new { request, result });
						break;
					case ResponseTypes.Error:
						this.logger.Error("{commandName} Error".FormatWith(new { commandName }), new { request, result });
						break;
					case ResponseTypes.InvalidRequest:
						this.logger.Error("Invalid {commandName}".FormatWith(new { commandName }), new { request, result });
						break;
					case ResponseTypes.Unauthorized:
						this.logger.Error("Unauthorized {commandName}".FormatWith(new { commandName }), new { request, result });
						break;
					default:
						this.logger.Error("Command unknown response type", new { request, result });
						break;
				}

				return result;
			}
			catch (Exception exception)
			{
				logger.Error("Could not process request", new { request, exception, command });
				throw;
			}
		}
    }
}