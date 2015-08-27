namespace Archimedes.Data.MemoryRepositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
    using Models;

    public sealed class ArtifactRepository : MemoryRepository<Artifact>, IArtifactRepository
    {
	    public ArtifactRepository()
	    {
			for (int i=0; i < 50; i++)
		    {
			    base.Insert(new Artifact
			    {
				    Title = Faker.Lorem.Sentence(),
				    Description = Faker.Lorem.Paragraph(),
				    Link = $"http://{Faker.Internet.DomainName()}.{Faker.Internet.DomainSuffix()}/{Faker.Internet.DomainWord()}",
					CreatedOn = new DateTime(Faker.RandomNumber.Next(2004,2015), Faker.RandomNumber.Next(1,12), Faker.RandomNumber.Next(1, 28))
				});
		    }
		}

	    public override IEnumerable<Artifact> GetAll()
	    {
		    return base.GetAll().OrderByDescending(artifact => artifact.CreatedOn);
	    }

	    public int GetTotalCount()
	    {
		    return this.Storage.Count;
	    }

	    public List<Artifact> GetPagedArtifacts(int startIndex, int pageSize)
	    {
		    return this.GetAll().Skip(startIndex).Take(pageSize).ToList();
	    }

	    public override Artifact Insert(Artifact instance)
	    {
		    instance.CreatedOn = DateTime.Today;
		    return base.Insert(instance);
	    }
    }
}