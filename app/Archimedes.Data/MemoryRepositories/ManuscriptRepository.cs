namespace Archimedes.Data.MemoryRepositories
{
	using Archimedes.Data.Contracts;
	using Archimedes.Data.Models;

	public class ManuscriptRepository : MemoryRepository<Manuscript>, IManuscriptRepository
	{
		public ManuscriptRepository()
		{
			this.Insert(new Manuscript { Title = "Two Cathedrals", Description = "A look at wilderness and technology" });
			this.Insert(new Manuscript { Title = "A Triumph of Humanity", Description = "The story of my dad and the humans who saved him." });
		}
	}
}