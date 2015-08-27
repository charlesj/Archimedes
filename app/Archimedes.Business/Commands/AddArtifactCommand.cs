namespace Archimedes.Business.Commands
{
	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Models;

	public class AddArtifactCommand : BusinessCommand<AddArtifactRequest, Artifact>
	{
		public AddArtifactCommand(IBusinessServices businessServices) : base(businessServices)
		{
		}

		protected override Artifact Work()
		{
			// TODO Map this stuff, because this is boring...
			var artifact = new Artifact
			{
				Title = this.Request.Title,
			};

			return this.DataStore.Artifacts.Insert(artifact);
		}

		protected override bool Authorize()
		{
			return true;
		}
	}

	public class AddArtifactRequest : Request
	{
		public string Title { get; set; }
		public string Source { get; set; }
		public string Motivation { get; set; }
		public string Status { get; set; }
	}

	public class AddArtifactRequestValidator : BaseValidator<AddArtifactRequest>
	{
		public AddArtifactRequestValidator(IMappingService mapper) : base(mapper)
		{
		}
	}
}