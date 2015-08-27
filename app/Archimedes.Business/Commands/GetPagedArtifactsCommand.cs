namespace Archimedes.Business.Commands
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Models;

	using FluentValidation;
	
	public class GetPagedArtifactsCommand : BusinessCommand<GetPagedArtifactsRequest, GetPagedArtifactsResponse>
	{
		public GetPagedArtifactsCommand(IBusinessServices businessServices) : base(businessServices)
		{
		}

		protected override GetPagedArtifactsResponse Work()
		{
			var response = new GetPagedArtifactsResponse();

			response.Artifacts = this.DataStore.Artifacts.GetPagedArtifacts(this.Request.StartIndex, this.Request.PageSize);
			response.TotalArtifactCount = this.DataStore.Artifacts.GetTotalCount();

			response.OlderStartIndex = Math.Min(this.Request.StartIndex + this.Request.PageSize, response.TotalArtifactCount);
			response.NewerStartIndex = Math.Max(this.Request.StartIndex - this.Request.PageSize, 0);
			response.HasOlder = response.OlderStartIndex <= response.TotalArtifactCount;
			response.HasNewer = response.NewerStartIndex >= 0 && this.Request.StartIndex != 0;
			return response;
		}

		protected override bool Authorize()
		{
			return true;
		}
	}

	public class GetPagedArtifactsResponse
	{
		public List<Artifact> Artifacts { get; set; }
		public bool HasNewer { get; set; }
		public int NewerStartIndex { get; set; }
		public bool HasOlder { get; set; }
		public int OlderStartIndex { get; set; }
		public int TotalArtifactCount { get; set; }
	}

	public class GetPagedArtifactsRequest : Request
	{
		public int StartIndex { get; set; }
		public int PageSize { get; set; }
	}

	public class GetPagedArtifactsRequestValidator : BaseValidator<GetPagedArtifactsRequest>
	{
		public GetPagedArtifactsRequestValidator(IMappingService mapper) : base(mapper)
		{
			this.RuleFor(req => req.StartIndex).GreaterThanOrEqualTo(0);
			this.RuleFor(req => req.PageSize).GreaterThan(0);
		}
	}
}
