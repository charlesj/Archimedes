namespace Archimedes.Business.Commands.ManuscriptCommands
{
	using Archimedes.Common.Mapping;
	using Archimedes.Common.Validation;

	/// <summary>
	/// The get all manuscripts request.
	/// </summary>
	public class GetAllManuscriptsRequest : UnauthorizedRequest
	{
	}

	public class GetAllManuscriptsRequestValidator : BaseValidator<GetAllManuscriptsRequest>
	{
		public GetAllManuscriptsRequestValidator(IMappingService mapper)
			: base(mapper)
		{
		}
	}
}