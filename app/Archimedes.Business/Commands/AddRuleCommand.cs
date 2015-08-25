namespace Archimedes.Business.Commands
{
	using Common.Commands;
	using Common.Mapping;
	using Common.Validation;
	using Data.Models;

	public class AddRuleCommand : BusinessCommand<AddRuleRequest, Rule>
	{
		public AddRuleCommand(IBusinessServices businessServices) : base(businessServices)
		{
		}

		protected override Rule Work()
		{
			// TODO Map this stuff, because this is boring...
			var rule = new Rule
			{
				Motivation = this.Request.Motivation,
				Source = this.Request.Source,
				Title = this.Request.Title,
				Status = this.Request.Status
			};

			return this.DataStore.Rules.Insert(rule);
		}

		protected override bool Authorize()
		{
			return true;
		}
	}

	public class AddRuleRequest : Request
	{
		public string Title { get; set; }
		public string Source { get; set; }
		public string Motivation { get; set; }
		public string Status { get; set; }
	}

	public class AddRuleRequestValidator : BaseValidator<AddRuleRequest>
	{
		public AddRuleRequestValidator(IMappingService mapper) : base(mapper)
		{
		}
	}
}