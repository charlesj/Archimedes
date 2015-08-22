namespace Archimedes.Common.Validation
{
	public class ValidateThings : IValidateThings
	{
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
			var validator = Kernel.ServiceLocator.GetService<IValidate<T>>();
			return validator;
		}
	}
}