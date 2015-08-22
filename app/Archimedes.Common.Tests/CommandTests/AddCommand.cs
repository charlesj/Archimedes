namespace Archimedes.Common.Tests.CommandTests
{
	using System;
	using System.Linq;

	using Commands;
	using Mapping;
	using ServiceLocater;
	using Validation;

	using FluentValidation;
	using Xunit;

	public class AddCommandTests
	{
		public AddCommandTests()
		{
			// Ensure that we're booted
			Kernel.Boot(BootConfiguration.DefaultConfiguration);
			var ninjectKernal = ((NinjectServiceLocator)Kernel.ServiceLocator).Kernel;
			if (!ninjectKernal.GetBindings(typeof(BaseCommand<AddRequest, int>)).Any())
			{
				ninjectKernal.Bind<BaseCommand<AddRequest, int>>().To<AddCommand>();
			}
			if (!ninjectKernal.GetBindings(typeof (IValidate<AddRequest>)).Any())
			{
				ninjectKernal.Bind<IValidate<AddRequest>>().To<AddRequestValidator>();
			}
		}

		[Fact]
		public void CanExecuteCommand()
		{
			var command = Kernel.ServiceLocator.GetService<AddCommand>();
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
			var headquarters = Kernel.ServiceLocator.GetService<CommandExecutor>();
			var response = headquarters.Execute<AddRequest, int>(new AddRequest { FirstNumber = 2, SecondNumber = 2 });
			Assert.True(response.Result == 4);
		}

		[Fact]
		public void CanReadElapsed()
		{
			var headquarters = Kernel.ServiceLocator.GetService<CommandExecutor>();
			var response = headquarters.Execute<AddRequest, int>(new AddRequest { FirstNumber = 2, SecondNumber = 2 });
			Console.Write("Execution Time: {0}ms", response.ExecutionTime);
		}

		[Fact]
		public void InvalidRequestReturnsInvalidRequestTrue()
		{
			var command = Kernel.ServiceLocator.GetService<AddCommand>();
			var request = new AddRequest { FirstNumber = -1, SecondNumber = 1 }; // invalid because of the -1
			var response = command.Execute(request);
			Assert.Equal(response.ResultType, ResponseTypes.InvalidRequest);
		}

		[Fact]
		public void InvalidRequestReturnsValidationErrors()
		{
			var command = Kernel.ServiceLocator.GetService<AddCommand>();
			var request = new AddRequest { FirstNumber = -1, SecondNumber = 1 }; // invalid because of the -1
			var response = command.Execute(request);
			Assert.True(response.ValidationErrors.Any());
		}

		[Fact]
		public void UnauthorizedRequestReturnsUnauthorizedResponse()
		{
			var command = Kernel.ServiceLocator.GetService<AddCommand>();
			var request = new AddRequest { FirstNumber = 1, SecondNumber = 1 };
			command.AuthorizeOveride = false;
			var response = command.Execute(request);
			Assert.Equal(response.ResultType, ResponseTypes.Unauthorized);
		}
	}
	public class AddCommand : BaseCommand<AddRequest, int>
	{
		public bool AuthorizeOveride { get; set; }
		public AddCommand(IValidateThings valdiator)
			: base(valdiator)
		{
			AuthorizeOveride = true;
		}

		protected override int Work()
		{
			return this.Request.FirstNumber + this.Request.SecondNumber;
		}

		protected override bool Authorize()
		{
			return this.AuthorizeOveride;
		}
	}

	public class AddRequest : Request
	{
		public int FirstNumber { get; set; }

		public int SecondNumber { get; set; }
	}

	public class AddRequestValidator : BaseValidator<AddRequest>
	{
		public AddRequestValidator(IMappingService mapper)
			: base(mapper)
		{
			RuleFor(obj => obj.FirstNumber).GreaterThanOrEqualTo(0);
			RuleFor(obj => obj.SecondNumber).LessThanOrEqualTo(100);
		}
	}
}