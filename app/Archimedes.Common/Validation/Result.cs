namespace Archimedes.Common.Validation
{
	using System.Collections.Generic;

	public class Result
	{
		public Result()
		{
			this.FailureMessages = new List<FailureMessage>();
			this.IsValid = false;
		}

		public bool IsValid { get; set; }

		public List<FailureMessage> FailureMessages { get; set; }
	}
}
