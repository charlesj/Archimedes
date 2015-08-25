namespace Archimedes.Business.Commands
{
	using System.Collections.Generic;
	using System.Linq;
	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Models;

	public class GetRulesCommand : BusinessCommand<GetRulesRequest, List<Rule>>
	{
		public GetRulesCommand(IBusinessServices businessServices) : base(businessServices)
		{
		}

		protected override List<Rule> Work()
		{
			return this.DataStore.Rules.GetAll().ToList();
		}

		protected override bool Authorize()
		{
			return true;
		}
	}

	public class GetRulesRequest : Request
	{
	}

	public class GetRulesRequestValidator : BaseValidator<GetRulesRequest>
	{
		public GetRulesRequestValidator(IMappingService mapper) : base(mapper)
		{
		}
	}
}
