namespace Archimedes.Common.Commands
{
	public interface ICommandLocator
	{
		BaseCommand<TRequest, TResult> FindCommand<TRequest, TResult>() where TRequest : Request;
	}
}
