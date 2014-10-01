namespace Archimedes.Data.Contracts
{
	using Archimedes.Data.Models;

	public interface IUserRepository : IRepository<User>
	{
		User GetByUsername(string username);

		bool Validate(string username, string password);
	}
}