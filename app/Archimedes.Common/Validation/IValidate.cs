namespace Archimedes.Common.Validation
{
	public interface IValidate<in T>
	{
		Result Check(T validationTarget);
	}
}