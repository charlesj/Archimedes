namespace Archimedes.Common.Tests.ValidationTests
{
	using System;
	using System.Diagnostics.CodeAnalysis;

	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using FluentValidation;

	using Xunit;

	public class ValidateThingsTests
    {
        private readonly ValidateThings validatorLocator;

        public ValidateThingsTests()
        {
            MappingConfigurationLoader.LoadConfigurations();
            this.validatorLocator = new ValidateThings(new AutoMapperMappingService());
        }

        [Fact]
        public void CanValidate()
        {
            var simple = new Simple { Name = "Fozzy", EmailAddress = "fozzy@wokka.com" };
            Assert.DoesNotThrow(() => this.validatorLocator.CheckValidation(simple));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenItCannotLocateAValidator()
        {
            Assert.Throws<InvalidOperationException>(() => this.validatorLocator.CheckValidation("wokka wokka"));
        }

        [Fact]
        public void ThrowsWhenGivenAValidatorWithAConstructorWithMultipleArguments()
        {
            var brick = new Brick();
            Assert.Throws<InvalidOperationException>(() => this.validatorLocator.CheckValidation(brick));
        }

        private class Simple
        {
            public string Name { get; set; }

            public string EmailAddress { get; set; }
        }

        private class Brick
        {
        }

        private class BrickValidator : BaseValidator<Brick>
        {
            private readonly string name;

            public BrickValidator(IMappingService mapper, string name)
                : base(mapper)
            {
                this.name = name;
            }
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
