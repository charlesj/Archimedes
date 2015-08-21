namespace Archimedes.Data.MemoryRepositories
{
	using System.Collections.Generic;
	using System.Linq;

	using Archimedes.Data.Contracts;
	using Archimedes.Data.Models;

	public class MemoryRepository<TModel> : IRepository<TModel>
		where TModel : IModel
	{
		public MemoryRepository()
		{
			this.Storage = new MemoryStorage<TModel>();
		}

		protected MemoryStorage<TModel> Storage { get; private set; }

		public TModel Get(int id)
		{
			return this.Storage[id];
		}

		public TModel Insert(TModel instance)
		{
			return this.Storage.Insert(instance);
		}

		public TModel Update(TModel instance)
		{
			this.Storage[instance.Id] = instance;
			return instance;
		}

		public void Delete(int id)
		{
			this.Storage.Remove(id);
		}

		public IEnumerable<TModel> GetAll()
		{
			return this.Storage.Select(kvp => kvp.Value);
		}
	}
}