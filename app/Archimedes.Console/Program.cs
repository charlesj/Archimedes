namespace Archimedes.Console
{
	using Common;
	using Common.Commands;
	using Commands;
	using System.Diagnostics;

	public class Program
	{
		public static void Main(string[] args)
		{
			Bootstrapper.Boot(
				BootConfiguration.DefaultConfiguration
								 .BeVerbose()
								 .AddNinjectModule(new CommonNinjectModule())
								 .AddNinjectModule(new ConsoleNinjectModule()));
			var executor = Bootstrapper.BootedKernel.ServiceLocator.GetService<CommandExecutor>();
			var response = executor.Execute<NullRequest, bool>(new NullRequest());

			Debug.Assert(response.ResultType == ResponseTypes.Success);
		}
	}
}