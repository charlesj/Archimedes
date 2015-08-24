namespace Archimedes.Data.MemoryRepositories
{
	using System.Collections.Generic;

	using Models;

	public class MemoryStorage<TModel> : Dictionary<int, TModel> where TModel : IModel
	{
		private int lastId;

		public TModel Insert(TModel instance)
		{
			instance.Id = ++this.lastId;
			this.Add(this.lastId, instance);
			return instance;
		}
	}
}