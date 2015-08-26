using System.Linq;

namespace Archimedes.Data.MemoryRepositories
{
    using Contracts;
    using Models;

    public class RuleRepository : MemoryRepository<Rule>, IRuleRepository
    {
	    public RuleRepository()
	    {
		    this.Insert(new Rule
		    {
			    Title = "We don't talk about rules",
			    Source = "Default Settings",
			    Status = "Suggested",
			    Motivation = "We need something to work with"
		    });

			this.Insert(new Rule
			{
				Title = "We DON'T talk about rules",
				Source = "Default Settings",
				Status = "Enforced",
				Motivation = "Don't want to get with the chain of command"
			});

			for (int i=0; i < 50; i++)
		    {
			    this.Insert(new Rule
			    {
				    Title = Faker.Lorem.Sentence(),
				    Source = string.Join(" ", Faker.Lorem.Words(2)),
				    Status = "Enforced",
				    Motivation = Faker.Lorem.Sentence()
				});
		    }
		}
    }
}
