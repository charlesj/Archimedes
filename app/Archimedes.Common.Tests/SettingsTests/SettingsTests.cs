namespace Archimedes.Common.Tests.SettingsTests
{
    using System;

    using Common;
    using Exceptions;
    using Settings;

    using Xunit;

    public class SettingsTests
	{
		[Fact]
		public void CanInstantiateSettings()
		{
			var settings = new Settings(new TypeConverter());
		} 

		[Fact]
		public void CheckSettingsForValuesPasses()
		{
			var settings = new Settings(new TypeConverter());
			settings.CheckAllSettingForValues();
		}

		[Fact]
		public void BadSettingsFailsSanityCheck()
		{
			var settings = new BadSettings(new TypeConverter());
			Assert.Throws<ErrorCodeException>(() => settings.CheckAllSettingForValues());
		}

		[Fact]
		public void BadSettingsTryingToBeGoodFailsOnConstruction()
		{
			Assert.Throws<ErrorCodeException>(() => new BadSettingsTryingToBeGood(new TypeConverter()));
		}

		[Fact]
		public void CanInstantiateTestingSettings()
		{
			var testSettings = new TestingSettings(new TypeConverter());
		}

		[Fact]
		public void TestingSettingsPassesSanityCheck()
		{
			var settings = new TestingSettings(new TypeConverter());
			settings.CheckAllSettingForValues();
		}

		[Fact]
		public void CanInstantiateTestingSettingsUsingReflection()
		{
			var settings = new TestingSettingsUsingReflection(new TypeConverter());
		}

		[Fact]
		public void TestingReflectiveSettingsPassesSanityCheck()
		{
			var settings = new TestingSettingsUsingReflection(new TypeConverter());
			settings.CheckAllSettingForValues();
		}

		[Fact]
		public void BadReflectiveSettingsCannotInstantiate()
		{
			Assert.Throws<ErrorCodeException>(() => new BadReflectiveSettings(new TypeConverter()));
		}

		internal class BadSettings : Settings
		{
			public BadSettings(ITypeConverter typeConverter) : base(typeConverter)
			{
			}

			public string MissingConfigurationKey { get; set; }
		}

		internal class BadSettingsTryingToBeGood : Settings
		{
			public BadSettingsTryingToBeGood(ITypeConverter typeConverter) : base(typeConverter)
			{
				this.MissingConfigurationKey = this.GetValue<string>("MissingConfigurationKey");
			}

			public string MissingConfigurationKey { get; set; }
		}

		internal class TestingSettings : Settings
		{
			public TestingSettings(ITypeConverter typeConverter)
				: base(typeConverter)
			{
				this.CustomIntValue = this.GetValue<int>("CustomIntValue");
				this.GlobalIdentifier = this.GetValue<Guid>("GlobalIdentifier");
				this.CreatedOn = this.GetValue<DateTime>("CreatedOn");
			}

			public int CustomIntValue { get; set; }

			public Guid GlobalIdentifier { get; set; }

			public DateTime CreatedOn { get; set; }
		}

		internal class TestingSettingsUsingReflection : ReflectiveSettings
		{
			public TestingSettingsUsingReflection(ITypeConverter typeConverter) : base(typeConverter)
			{
			}

			public int CustomIntValue { get; set; }

			public Guid GlobalIdentifier { get; set; }

			public DateTime CreatedOn { get; set; }
		}

		internal class BadReflectiveSettings : ReflectiveSettings
		{
			public BadReflectiveSettings(ITypeConverter typeConverter) : base(typeConverter)
			{
			}

			public int MissingValue { get; set; }
		}
	}
}