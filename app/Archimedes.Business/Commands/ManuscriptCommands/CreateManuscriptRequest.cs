namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using System.Data;

	using Archimedes.Common.Commands;
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using FluentValidation;

	/// <summary>
	/// The create manuscript request.
	/// </summary>
	public class CreateManuscriptRequest : UnauthorizedRequest
	{
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }
	}

	public class CreateManuscriptRequestValidator : BaseValidator<CreateManuscriptRequest>
	{
		public CreateManuscriptRequestValidator(IMappingService mapper)
			: base(mapper)
		{
			RuleFor(req => req.Title).NotEmpty();
		}
	}
}