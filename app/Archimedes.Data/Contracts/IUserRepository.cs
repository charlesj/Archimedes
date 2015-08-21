namespace Archimedes.Data.Contracts
{
	using Models;

	public interface IUserRepository : IRepository<User>
	{
		User GetByUsername(string username);

		bool Validate(string username, string password);
	}
}