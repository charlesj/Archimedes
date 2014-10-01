namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using System.Collections.Generic;

	using Archimedes.Business.BusinessObjects;

	/// <summary>
	/// The get all manuscripts command.
	/// </summary>
	public class GetAllManuscriptsCommand : BusinessCommand<GetAllManuscriptsRequest, List<Manuscript>>
	{
		public GetAllManuscriptsCommand(IBusinessServices businessServices)
			: base(businessServices)
		{
		}

		/// <summary>
		/// The work.
		/// </summary>
		/// <returns>
		/// The <see cref="List"/>.
		/// </returns>
		protected override List<Manuscript> Work()
		{
			var all = this.DataStore.Manuscripts.GetAll();
			var mapped = this.Mapper.Map<IEnumerable<Data.Models.Manuscript>, List<Manuscript>>(all);
			return mapped;
		}
	}
}