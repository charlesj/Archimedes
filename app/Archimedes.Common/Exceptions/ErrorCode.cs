namespace Archimedes.Common.Exceptions
{
	public class ErrorCode
	{
		private readonly string classification;

		private readonly int identifier;

		private readonly string shortDescription;

		protected ErrorCode(string classification, int identifier, string shortDescription)
		{
			this.classification = classification;
			this.identifier = identifier;
			this.shortDescription = shortDescription;
		}

		public string Classification
		{
			get
			{
				return this.classification;
			}
		}

		public int Identifier
		{
			get
			{
				return this.identifier;
			}
		}

		public string ShortDescription
		{
			get
			{
				return this.shortDescription;
			}
		}

		public string FullIdentifier
		{
			get
			{
				return string.Format("{0}{1}", this.Classification, this.Identifier);
			}
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", this.FullIdentifier, this.ShortDescription);
		}
	}
}