namespace Archimedes.Data.Contracts
{
	using System.Collections.Generic;

	using Archimedes.Data.Models;

	/// <summary>
	/// The Repository interface.
	/// </summary>
	public interface IRepository<TModel> where TModel : IModel
	{
		TModel Get(int id);

		TModel Insert(TModel instance);

		TModel Update(TModel instance);

		void Delete(TModel instance);

		IEnumerable<TModel> GetAll();
	}
}
