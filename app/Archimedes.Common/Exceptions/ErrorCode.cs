namespace Archimedes.Common.Exceptions
{
    /// <summary>
    /// An Error Code represents identifiable information about a specific error.  This class is READ ONLY (following initialization).
    /// </summary>
    public class ErrorCode
    {
        /// <summary>
        /// The classification.
        /// </summary>
        private readonly string classification;

        /// <summary>
        /// The identifier.
        /// </summary>
        private readonly int identifier;

        /// <summary>
        /// The short description.
        /// </summary>
        private readonly string shortDescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCode"/> class.
        /// </summary>
        /// <param name="classification">
        /// The classification.
        /// </param>
        /// <param name="identifier">
        /// The identifier.
        /// </param>
        /// <param name="shortDescription">
        /// The short description.
        /// </param>
        protected ErrorCode(string classification, int identifier, string shortDescription)
        {
            this.classification = classification;
            this.identifier = identifier;
            this.shortDescription = shortDescription;
        }

        /// <summary>
        /// Gets the classification. This is a short string that is prepended to the full identifier.
        /// </summary>
        public string Classification
        {
            get
            {
                return this.classification;
            }
        }

        /// <summary>
        /// Gets the identifier.  This is a number that should basically increment, starting at 100.
        /// </summary>
        public int Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        /// <summary>
        /// Gets the short description.  This description is for internal use, and may be exposed to support staff.
        /// </summary>
        public string ShortDescription
        {
            get
            {
                return this.shortDescription;
            }
        }

        /// <summary>
        /// Gets the full identifier.  The full identifier is what is presented to end users.  It is also the identifier used
        /// for localization.  An example full identifier would be "COMMON100"
        /// </summary>
        public string FullIdentifier
        {
            get
            {
                return string.Format("{0}{1}", this.Classification, this.Identifier);
            }
        }

        /// <summary>
        /// Combines the FullIdentifer with the ShortDescription e.g. "FI - Description"
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", this.FullIdentifier, this.ShortDescription);
        }
    }
}