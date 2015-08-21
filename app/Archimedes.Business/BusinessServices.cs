namespace Archimedes.Business
{
	using Common.Mapping;
	using Common.Validation;
	using Data.Contracts;

	public class BusinessServices : IBusinessServices
	{
		public BusinessServices(IMappingService mapper, IValidateThings validator, IDataStorage dataStore)
		{
			this.Mapper = mapper;
			this.Validator = validator;
			this.DataStore = dataStore;
		}

		public IDataStorage DataStore { get; }

		public IMappingService Mapper { get; }

		public IValidateThings Validator { get; }
	}
}