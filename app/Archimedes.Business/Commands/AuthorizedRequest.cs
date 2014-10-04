namespace Archimedes.Business.Commands
{
	using Archimedes.Common.Commands;

	/// <summary>
	/// The authorized request.
	/// </summary>
	public class AuthorizedRequest : Request
	{
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		public virtual int RequestingUserId { get; set; }
	}

	public class UnauthorizedRequest : AuthorizedRequest
	{
		public override int RequestingUserId
		{
			get
			{
				return -1;
			}

			set
			{
				// no op  We don't want to do anything
			}
		}
	}
}
