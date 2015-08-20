namespace Archimedes.Common.Validation
{
	using System;
	using System.Linq;

	using Mapping;

	public class ValidateThings : IValidateThings
	{
		private readonly IMappingService mappingService;

		public ValidateThings(IMappingService mappingService)
		{
			this.mappingService = mappingService;
		}

		public void CheckValidationAndThrow<T>(T obj)
		{
			var result = this.CheckValidation(obj);
			if (!result.IsValid)
			{
				throw new ValidationException(result);
			}
		}

		public Result CheckValidation<T>(T obj)
		{
			var validator = this.LocateValidator<T>();
			return validator.Check(obj);
		}

		private IValidate<T> LocateValidator<T>()
		{            
			var argumentType = typeof(T);
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in assemblies)
			{
				if (assembly.GetTypes().Any(t => t.GetInterfaces().Contains(typeof(IValidate<T>))))
				{
					var type = assembly.GetTypes().First(t => t.GetInterfaces().Contains(typeof(IValidate<T>)));
					try
					{
						// TODO: Use service locator for this.
						var validator = Activator.CreateInstance(type, new object[] { this.mappingService }) as IValidate<T>;
						//var validator = Kernel.BootedKernel.ServiceLocator.GetService<IValidate<T>>();
						return validator;
					}
					catch (Exception e)
					{
						var constructorMessage =
							string.Format(
								"There was a problem constructing the validator for type {0}.  This is most likely "
								+ "caused by a validator that does not have the expected constructor signature. Check "
								+ "inner exception for more information.",
								argumentType.FullName);
						throw new InvalidOperationException(constructorMessage, e);
					}
				}
			}
			
			var message = string.Format("Could not locate a validator for type {0}", argumentType.FullName);
			throw new InvalidOperationException(message);
		}
	}
}