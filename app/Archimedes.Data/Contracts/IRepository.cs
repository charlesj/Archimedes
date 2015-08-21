namespace Archimedes.Data.Contracts
{
	using System.Collections.Generic;
	using Models;

	/// <summary>
	/// The Repository interface.
	/// </summary>
	public interface IRepository<TModel> where TModel : IModel
	{
		TModel Get(int id);

		TModel Insert(TModel instance);

		TModel Update(TModel instance);

		void Delete(int id);

		IEnumerable<TModel> GetAll();
	}
}