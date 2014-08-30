namespace Archimedes.Common.Tests.CommandTests
{
	using System;

	using Archimedes.Common.Commands;

	using Ninject.Modules;

	using Xunit;

	public class AddCommandTests
	{
		public AddCommandTests()
		{
			Bootstrapper.Boot(BootConfiguration.DefaultConfiguration);
		}

		[Fact]
		public void CanExecuteCommand()
		{
			var command = new AddCommand();
			var request = new AddRequest { FirstNumber = 1, SecondNumber = 1 };
			var response = command.Execute(request);
			Assert.True(response.Result == 2);
		}

		[Fact]
		public void CanUseLocator()
		{
			var locator = new CommandLocator();
			var command  = locator.FindCommand<AddRequest, int>();
			Assert.NotNull(command);
		}

		[Fact]
		public void CanUseHeadquarters()
		{
			var headquarters = Bootstrapper.BootedKernel.ServiceLocater.GetService<Headquarters>();
			var response = headquarters.Execute<AddRequest, int>(new AddRequest { FirstNumber = 2, SecondNumber = 2 });
			Assert.True(response.Result == 4);
		}

		[Fact]
		public void CanReadElapsed()
		{
			var headquarters = Bootstrapper.BootedKernel.ServiceLocater.GetService<Headquarters>();
			var response = headquarters.Execute<AddRequest, int>(new AddRequest { FirstNumber = 2, SecondNumber = 2 });
			Console.Write("Execution Time: {0}ms", response.ExecutionTime);
		}
	}

	public class AddCommandNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<BaseCommand<AddRequest, int>>().To<AddCommand>();
		}
	}

	public class AddCommand : BaseCommand<AddRequest, int>
	{
		protected override int Work()
		{
			return this.Request.FirstNumber + this.Request.SecondNumber;
		}
	}

	public class AddRequest : Request
	{
		public int FirstNumber { get; set; }

		public int SecondNumber { get; set; }
	}
}