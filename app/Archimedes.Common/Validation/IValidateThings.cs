namespace Archimedes.Common.Validation
{
	public interface IValidateThings
	{
		void CheckValidationAndThrow<T>(T obj);
		Result CheckValidation<T>(T obj);
	}
}