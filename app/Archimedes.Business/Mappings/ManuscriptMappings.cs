namespace Archimedes.Business.Mappings
{
	using Archimedes.Business.BusinessObjects;
	using Archimedes.Common.Mapping;

	using AutoMapper;

	/// <summary>
	/// The manuscript mappings.
	/// </summary>
	public class ManuscriptMappings : IMappingConfiguration
	{
		/// <summary>
		/// The configure.
		/// </summary>
		public void Configure()
		{
			Mapper.CreateMap<Data.Models.Manuscript, Manuscript>();
		}
	}
}