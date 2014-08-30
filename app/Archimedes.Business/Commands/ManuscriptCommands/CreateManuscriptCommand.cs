namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using Archimedes.Business.BusinessObjects;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;
	using Archimedes.Data.Contracts;

	/// <summary>
	/// The create manuscript command.
	/// </summary>
	public class CreateManuscriptCommand : BusinessCommand<CreateManuscriptRequest, Manuscript>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CreateManuscriptCommand"/> class.
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
		public CreateManuscriptCommand(IMappingService mapper, IValidateThings validator, IDataStorage data)
			: base(mapper, validator, data)
		{
			this.ErrorMessage = "Could not create new manuscript";
			this.SuccessMessage = "Successfully created new manuscript!";
		}

		/// <summary>
		/// The work.
		/// </summary>
		/// <returns>
		/// The <see cref="Manuscript"/>.
		/// </returns>
		protected override Manuscript Work()
		{
			var created = this.Data.Manuscripts.Insert(
				new Data.Models.Manuscript { Title = this.Request.Title, Description = this.Request.Description });
			var mapped = this.Mapper.Map<Data.Models.Manuscript, Manuscript>(created);
			return mapped;
		}
	}
}