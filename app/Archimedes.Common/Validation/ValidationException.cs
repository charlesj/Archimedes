namespace Archimedes.Common.Validation
{
	using System;
	using System.Collections.Generic;

	public class ValidationException : Exception
	{
		private readonly System.Collections.IDictionary data;

		public ValidationException() : this(new Result { IsValid = false })
		{
		}

		public ValidationException(Result result) : base("There was a problem validating the submission. See data property for messages.")
		{
			this.data = new Dictionary<string, string>();
			foreach (var message in result.FailureMessages)
			{
				this.data.Add(message.PropertyName, message.Message);
			}
		}

		public override System.Collections.IDictionary Data
		{
			get
			{
				return this.data;
			}
		}
	}
}