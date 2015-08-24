namespace Archimedes.Data.Contracts
{
	public interface IDataStorage
	{
        IRuleRepository Rules { get; set; }
	}
}