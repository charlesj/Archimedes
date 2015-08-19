namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using Archimedes.Business.BusinessObjects;

    /// <summary>
	/// The create manuscript command.
	/// </summary>
	public class CreateManuscriptCommand : BusinessCommand<CreateManuscriptRequest, Manuscript>
	{
		public CreateManuscriptCommand(IBusinessServices businessServices)
			: base(businessServices)
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
			var created = this.DataStore.Manuscripts.Insert(
			new Data.Models.Manuscript { Title = this.Request.Title, Description = this.Request.Description });
			var mapped = this.Mapper.Map<Data.Models.Manuscript, Manuscript>(created);
			return mapped;
		}
	}
}