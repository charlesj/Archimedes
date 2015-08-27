namespace Archimedes.Data.Contracts
{
	public interface IDataStorage
	{
        IArtifactRepository Artifacts { get; set; }
	}
}