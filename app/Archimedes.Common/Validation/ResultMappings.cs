namespace Archimedes.Common.Validation
{
	using System.Collections.Generic;

	using Archimedes.Common.Mapping;

	using AutoMapper;

	using FluentValidation.Results;

	public class ResultMappings : IMappingConfiguration
	{
		public void Configure()
		{
			Mapper.CreateMap<ValidationFailure, FailureMessage>()
				  .ForMember(
					  destination => destination.Message, option => option.MapFrom(source => source.ErrorMessage));

			Mapper.CreateMap<ValidationResult, Result>()
				  .ForMember(
					  destination => destination.FailureMessages,
					  option =>
					  option.MapFrom(source => Mapper.Map<IEnumerable<ValidationFailure>, List<FailureMessage>>(source.Errors)));
		}
	}
}