namespace Archimedes.Console.Commands
{
	using System;
	using Common.Commands;
	using Common.Validation;
	using Common.Mapping;

	public class NullCommand : BaseCommand<NullRequest, bool>
	{
		public NullCommand(IValidateThings validator) : base(validator)
		{
		}

		protected override bool Authorize()
		{
			return true;
		}

		protected override bool Work()
		{
			Console.WriteLine("This is a null command.");
			return true;
		}
	}

	public class NullRequest : Request
	{
	}

	public class NullRequestValidator : BaseValidator<NullRequest>
	{
		public NullRequestValidator(IMappingService mapper) : base(mapper)
		{
		}
	}
}
