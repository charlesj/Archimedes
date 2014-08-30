namespace Archimedes.Web.Results
{
	/// <summary>
	/// The ajax error result.
	/// </summary>
	public class AjaxErrorResult : AjaxResult
	{
		 /// <summary>
		 /// Initializes a new instance of the <see cref="AjaxErrorResult"/> class. 
		 /// </summary>
		 /// <param name="message">
		 /// The message.
		 /// </param>
		 /// <param name="data">
		 /// The data.
		 /// </param>
        public AjaxErrorResult(string message, object data)
        {
            this.Message = message;
            this.Data = new { status = "error", message, data };
        }

        /// <summary>
        /// Gets the message.  Used during testing mainly.
        /// </summary>
        public string Message { get; private set; }
	}
}