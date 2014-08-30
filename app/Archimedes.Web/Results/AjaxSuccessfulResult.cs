namespace Archimedes.Web.Results
{
	/// <summary>
	/// The ajax successful result.
	/// </summary>
	public class AjaxSuccessfulResult : AjaxResult
	{
		 /// <summary>
		 /// Initializes a new instance of the <see cref="AjaxSuccessfulResult"/> class. 
		 /// </summary>
		 /// <param name="data">
		 /// The data.
		 /// </param>
		public AjaxSuccessfulResult(object data)
        {
            this.RawData = data;
            this.Data = new { status = "success", data };
        }

        /// <summary>
        /// Gets the raw data.
        /// </summary>
        public object RawData { get; private set; } 
	}
}