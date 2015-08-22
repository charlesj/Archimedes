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
			Kernel.Boot(
				BootConfiguration.DefaultConfiguration
								 .BeVerbose()
								 .AddNinjectModule(new CommonNinjectModule())
								 .AddNinjectModule(new ConsoleNinjectModule()));
			var executor = Kernel.ServiceLocator.GetService<CommandExecutor>();
			var response = executor.Execute<NullRequest, bool>(new NullRequest());

			Debug.Assert(response.ResultType == ResponseTypes.Success);
		}
	}
}