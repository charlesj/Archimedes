namespace Archimedes.Business
{
	using Archimedes.Business.Contracts;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;
	using Archimedes.Data.Contracts;

	public class BusinessServices : IBusinessServices
	{
		public BusinessServices(IMappingService mapper, IValidateThings validator, IDataStorage dataStore, IUserActivityLog userActivityLog)
		{
			this.Mapper = mapper;
			this.Validator = validator;
			this.DataStore = dataStore;
			this.UserActivityLog = userActivityLog;
		}

		public IMappingService Mapper { get; private set; }

		public IValidateThings Validator { get; private set; }

		public IDataStorage DataStore { get; private set; }

		public IUserActivityLog UserActivityLog { get; private set; }
	}
}