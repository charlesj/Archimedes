namespace Archimedes.Business
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;
	using Archimedes.Data.Contracts;

	public interface IBusinessServices
	{
		IMappingService Mapper{ get; }

		IValidateThings Validator { get; }

		IDataStorage DataStore { get; }
	}
}