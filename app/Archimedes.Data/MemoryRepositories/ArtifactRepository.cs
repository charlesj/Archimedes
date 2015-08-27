namespace Archimedes.Data.MemoryRepositories
{
    using Contracts;
    using Models;

    public class ArtifactRepository : MemoryRepository<Artifact>, IArtifactRepository
    {
	    public ArtifactRepository()
	    {
			for (int i=0; i < 50; i++)
		    {
			    this.Insert(new Artifact
			    {
				    Title = Faker.Lorem.Sentence(),
				    Description = Faker.Lorem.Paragraph(),
				    Link = Faker.Internet.DomainName()
				});
		    }
		}
    }
}
