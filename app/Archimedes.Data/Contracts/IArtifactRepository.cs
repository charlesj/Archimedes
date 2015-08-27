using System.Collections.Generic;

namespace Archimedes.Data.Contracts
{
    using Models;

    public interface IArtifactRepository : IRepository<Artifact>
    {
	    int GetTotalCount();
	    List<Artifact> GetPagedArtifacts(int startIndex, int pageSize);
    }
}
