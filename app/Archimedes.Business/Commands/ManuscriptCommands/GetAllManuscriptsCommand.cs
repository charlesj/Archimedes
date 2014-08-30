namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using System.Collections.Generic;

	using Archimedes.Business.BusinessObjects;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;
	using Archimedes.Data.Contracts;

	/// <summary>
	/// The get all manuscripts command.
	/// </summary>
	public class GetAllManuscriptsCommand : BusinessCommand<GetAllManuscriptsRequest, List<Manuscript>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetAllManuscriptsCommand"/> class.
		/// </summary>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		/// <param name="validator">
		/// The validator.
		/// </param>
		/// <param name="data">
		/// The data.
		/// </param>
		public GetAllManuscriptsCommand(IMappingService mapper, IValidateThings validator, IDataStorage data)
			: base(mapper, validator, data)
		{
			this.ErrorMessage = "Could not get your manuscripts";
		}

		/// <summary>
		/// The work.
		/// </summary>
		/// <returns>
		/// The <see cref="List"/>.
		/// </returns>
		protected override List<Manuscript> Work()
		{
			var all = this.Data.Manuscripts.GetAll();
			var mapped = this.Mapper.Map<IEnumerable<Data.Models.Manuscript>, List<Manuscript>>(all);
			return mapped;
		}
	}
}