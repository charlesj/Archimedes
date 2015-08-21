namespace Archimedes.Data.MemoryRepositories
{
	using System;

	using Contracts;
	using Models;

	public class ManuscriptRepository : MemoryRepository<Manuscript>, IManuscriptRepository
	{
		public ManuscriptRepository()
		{
			this.Insert(new Manuscript { Title = "Two Cathedrals", Description = "A look at wilderness and technology", CreatedOn = new DateTime(2014, 5, 16), LastUpdated = new DateTime(2014, 6, 18) });
			this.Insert(new Manuscript { Title = "A Triumph of Humanity", Description = "The story of my dad and the humans who saved him.", CreatedOn = new DateTime(2014, 6, 21), LastUpdated = new DateTime(2014, 8, 18) });
		}
	}
}