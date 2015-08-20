namespace Archimedes.Common.Mapping
{
	public interface IMappingService
	{
		TDestination Map<TSource, TDestination>(TSource source) where TDestination : class;
	}
}