namespace Archimedes.Common.Mapping
{
	using AutoMapper;
	
	public class AutoMapperMappingService : IMappingService
	{
		public TDestination Map<TSource, TDestination>(TSource source) where TDestination : class
		{
			return Mapper.Map<TSource, TDestination>(source);
		}
	}
}