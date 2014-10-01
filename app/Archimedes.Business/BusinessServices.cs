namespace Archimedes.Business
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;
	using Archimedes.Data.Contracts;

	public class BusinessServices : IBusinessServices
	{
		public BusinessServices(IMappingService mapper, IValidateThings validator, IDataStorage dataStore)
		{
			this.Mapper = mapper;
			this.Validator = validator;
			this.DataStore = dataStore;
		}

		public IMappingService Mapper { get; private set; }

		public IValidateThings Validator { get; private set; }

		public IDataStorage DataStore { get; private set; }
	}
}