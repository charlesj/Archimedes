namespace Archimedes.Business.Commands
{
	using System.Collections.Generic;
	using System.Linq;
	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Models;

	using FluentValidation;


	public class GetArtifactsCommand : BusinessCommand<GetArtifactsRequest, GetArtifactsResponse>
	{
		public GetArtifactsCommand(IBusinessServices businessServices) : base(businessServices)
		{
		}

		protected override GetArtifactsResponse Work()
		{
			var response = new GetArtifactsResponse();
			
			var all = this.DataStore.Artifacts.GetAll();
			if (this.Request.PageSize.HasValue && this.Request.StartIndex.HasValue)
			{
				response.Artifacts = all.Skip(this.Request.StartIndex.Value).Take(this.Request.PageSize.Value).ToList();
			}
			else
			{
				response.Artifacts = all.ToList();
			}

			return response;
		}

		protected override bool Authorize()
		{
			return true;
		}
	}

	public class GetArtifactsResponse
	{
		public List<Artifact> Artifacts { get; set; }
	}

	public class GetArtifactsRequest : Request
	{
		public int? StartIndex { get; set; }
		public int? PageSize { get; set; }
	}

	public class GetArtifactsRequestValidator : BaseValidator<GetArtifactsRequest>
	{
		public GetArtifactsRequestValidator(IMappingService mapper) : base(mapper)
		{
			this.When(req => req.StartIndex.HasValue, () =>
			{
				this.RuleFor(req => req.StartIndex).GreaterThanOrEqualTo(0);
				this.RuleFor(req => req.PageSize).NotNull();
			});

			this.When(req => req.PageSize.HasValue, () =>
			{
				this.RuleFor(req => req.PageSize).GreaterThan(0);
				this.RuleFor(req => req.StartIndex).NotNull();
			});
		}
	}
}
