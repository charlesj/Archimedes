namespace Archimedes.Common.Tests.ValidationTests
{
	using System.Linq;

	using Mapping;
	using Validation;

	using FluentValidation;

	using Ninject;

	using Xunit;

	public class ValidatorTests
    {
        [Fact]
        public void CanValidateSimple()
        {
            var simple = new Simple { Name = "Fozzy", EmailAddress = "fozzy@wokka.com" };
            MappingConfigurationLoader.LoadConfigurations();
            IValidate<Simple> valid = new SimpleValidator(new AutoMapperMappingService());
            var result = valid.Check(simple);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void CanInvalidateSimple()
        {
            var simple = new Simple();
            MappingConfigurationLoader.LoadConfigurations();
            IValidate<Simple> valid = new SimpleValidator(new AutoMapperMappingService());
            var result = valid.Check(simple);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void CanLoadFromNinject()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IValidate<Simple>>().To<SimpleValidator>();
            kernel.Bind<IMappingService>().To<AutoMapperMappingService>();
            kernel.Get<IValidate<Simple>>();
        }

        [Fact]
        public void ValidationMessagesAreCorrectlyTransformed()
        {
            var simple = new Simple();
            MappingConfigurationLoader.LoadConfigurations();
            var validator = new SimpleValidator(new AutoMapperMappingService());

            var fluentResults = validator.Validate(simple);
            var myResults = validator.Check(simple);

            Assert.Equal(fluentResults.IsValid, myResults.IsValid);

            foreach (var thing in fluentResults.Errors)
            {
                Assert.True(myResults.FailureMessages.Any(fm => fm.Message == thing.ErrorMessage));
            }
        }

        private class Simple
        {
            public string Name { get; set; }

            public string EmailAddress { get; set; }
        }

        private class SimpleValidator : BaseValidator<Simple>
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