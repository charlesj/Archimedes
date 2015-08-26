using FluentValidation;

namespace Archimedes.Business.Commands
{
	using System.Collections.Generic;
	using System.Linq;
	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Models;

	public class GetRulesCommand : BusinessCommand<GetRulesRequest, GetRulesResponse>
	{
		public GetRulesCommand(IBusinessServices businessServices) : base(businessServices)
		{
		}

		protected override GetRulesResponse Work()
		{
			var response = new GetRulesResponse();
			
			var all = this.DataStore.Rules.GetAll();
			if (this.Request.PageSize.HasValue && this.Request.StartIndex.HasValue)
			{
				response.FoundRules = all.Skip(this.Request.StartIndex.Value).Take(this.Request.PageSize.Value).ToList();
			}
			else
			{
				response.FoundRules = all.ToList();
			}

			return response;
		}

		protected override bool Authorize()
		{
			return true;
		}
	}

	public class GetRulesResponse
	{
		public List<Rule> FoundRules { get; set; }
	}

	public class GetRulesRequest : Request
	{
		public int? StartIndex { get; set; }
		public int? PageSize { get; set; }
	}

	public class GetRulesRequestValidator : BaseValidator<GetRulesRequest>
	{
		public GetRulesRequestValidator(IMappingService mapper) : base(mapper)
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
