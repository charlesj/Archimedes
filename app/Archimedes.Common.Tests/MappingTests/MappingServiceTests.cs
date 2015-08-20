namespace Archimedes.Common.Tests.MappingTests
{

	using Mapping;

	using AutoMapper;

	using Xunit;

	public class MappingServiceTests
	{
		[Fact]
		public void CanMapFromFootballToSoccer()
		{
			var config = new SportMappingConfiguration();
			config.Configure();

			var mapper = new AutoMapperMappingService();

			var soccer = new SoccerPlayer { Name = "Fozzy" };

			var mapped = mapper.Map<SoccerPlayer, FootballPlayer>(soccer);

			Assert.Equal("Fozzy", mapped.Name);
		}

		private class FootballPlayer
		{
			public string Name { get; set; }
		}

		private class SoccerPlayer
		{
			public string Name { get; set; }
		}

		private class SportMappingConfiguration : IMappingConfiguration
		{
			public void Configure()
			{
				Mapper.CreateMap<FootballPlayer, SoccerPlayer>();
				Mapper.CreateMap<SoccerPlayer, FootballPlayer>();
			}
		}
	}
}
