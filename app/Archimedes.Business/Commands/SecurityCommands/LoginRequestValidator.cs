namespace Archimedes.Business.Commands.SecurityCommands
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	using FluentValidation;

	/// <summary>
	/// The login request validator.
	/// </summary>
	public class LoginRequestValidator : BaseValidator<LoginRequest>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginRequestValidator"/> class.
		/// </summary>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		public LoginRequestValidator(IMappingService mapper)
			: base(mapper)
		{
			this.RuleFor(req => req.Username).NotNull().NotEmpty();
			this.RuleFor(req => req.Password).NotNull().NotEmpty();
		}
	}
}