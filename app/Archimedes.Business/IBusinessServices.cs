namespace Archimedes.Business
{
	using Common.Mapping;
	using Common.Validation;
	using Data.Contracts;

	public interface IBusinessServices
	{
		IMappingService Mapper{ get; }

		IValidateThings Validator { get; }

		IDataStorage DataStore { get; }
	}
}