namespace Archimedes.Common.Commands
{
	using System;

	using ErrorCodes;
	using Exceptions;
    
	public class CommandLocator : ICommandLocator
	{
		public BaseCommand<TRequest, TResult> FindCommand<TRequest, TResult>() where TRequest : Request
		{
			try
			{
				var command = Bootstrapper.BootedKernel.ServiceLocator.GetService<BaseCommand<TRequest, TResult>>();
				return command;
			}
			catch (Exception exception)
			{
			    var requestType = typeof(TRequest);
			    var resultType = typeof(TResult);
				throw new ErrorCodeException(CommonErrors.CouldNotLocateCommand, exception, new { RequestType = requestType.ToString(), ResultType = resultType.ToString() });
			}
		}
	}
}