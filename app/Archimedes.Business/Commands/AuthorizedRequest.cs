namespace Archimedes.Business.Commands
{
	using System;

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
				throw new InvalidOperationException("RequestingUserId is ignored on Unauthorized requests");
			}

			set
			{
				throw new InvalidOperationException("RequestingUserId is ignored on Unauthorized requests");
			}
		}
	}
}
