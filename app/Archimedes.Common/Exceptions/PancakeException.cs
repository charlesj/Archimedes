namespace Archimedes.Common.Exceptions
{
	using System;
	
	public class ArchimedesException : Exception
	{
				public ArchimedesException(string message, Exception innerException, object additionalData = null) : base(message, innerException)
		{
			this.AdditionalData = additionalData;
		}

		public ArchimedesException(string message, object additionalData = null) : base(message)
		{
			this.AdditionalData = additionalData;
		}

		private ArchimedesException() : base("Pancake Exception was thrown with no message")
		{
		}

		public object AdditionalData { get; private set; }
	}
}
