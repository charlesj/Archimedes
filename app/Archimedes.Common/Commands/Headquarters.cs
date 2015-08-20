namespace Archimedes.Common.Commands
{
	public class CommandExecutor
	{
		private readonly ICommandLocator commandLocator;

		public CommandExecutor(ICommandLocator commandLocator)
		{
			this.commandLocator = commandLocator;
		}

		public Response<TResult> Execute<TRequest, TResult>(TRequest request) where TRequest : Request
		{
			var command = this.commandLocator.FindCommand<TRequest, TResult>();
			return command.Execute(request);
		}
	}
}