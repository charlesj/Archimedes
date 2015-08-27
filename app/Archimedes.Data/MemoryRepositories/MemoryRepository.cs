namespace Archimedes.Data.MemoryRepositories
{
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Models;

	public class MemoryRepository<TModel> : IRepository<TModel>
		where TModel : IModel
	{
		public MemoryRepository()
		{
			this.Storage = new MemoryStorage<TModel>();
		}

		protected MemoryStorage<TModel> Storage { get; }

		public virtual TModel Get(int id)
		{
			return this.Storage[id];
		}

		public virtual TModel Insert(TModel instance)
		{
			return this.Storage.Insert(instance);
		}

		public virtual TModel Update(TModel instance)
		{
			this.Storage[instance.Id] = instance;
			return instance;
		}

		public virtual void Delete(int id)
		{
			this.Storage.Remove(id);
		}

		public virtual IEnumerable<TModel> GetAll()
		{
			return this.Storage.Select(kvp => kvp.Value);
		}
	}
}