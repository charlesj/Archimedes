namespace Archimedes.Common.Tests.ValidationTests
{
	using System.Linq;

	using Mapping;
	using ServiceLocater;
	using Validation;

	using FluentValidation;
	using Xunit;

	public class ValidateThingsTests : BaseIntegrationTest<IValidateThings>
	{
		public ValidateThingsTests()
		{
			// setup the service locator to know about this binding.
			var ninjectKernal = ((NinjectServiceLocator)Kernel.ServiceLocator).Kernel;
			if (!ninjectKernal.GetBindings(typeof(IValidate<Simple>)).Any())
			{
				ninjectKernal.Bind<IValidate<Simple>>().To<SimpleValidator>();
			}
		}

		[Fact]
		public void CanValidate()
		{
			var simple = new Simple { Name = "Fozzy", EmailAddress = "fozzy@wokka.com" };
			var result = this.SystemUnderTest.CheckValidation(simple);
			Assert.True(result.IsValid);
		}

		[Fact]
		public void CanInvalidate()
		{
			var simple = new Simple { Name = "Fozzy", EmailAddress = "fozzywokka.com" };
			var result = this.SystemUnderTest.CheckValidation(simple);
			Assert.False(result.IsValid);
		}

		public class Simple
		{
			public string Name { get; set; }

			public string EmailAddress { get; set; }
		}

		public class SimpleValidator : BaseValidator<Simple>
		{
			public SimpleValidator(IMappingService mapper)
				: base(mapper)
			{
				this.RuleFor(simple => simple.Name).NotEmpty();
				this.RuleFor(simple => simple.EmailAddress).EmailAddress();
			}
		}
	}
}