namespace Archimedes.Web.Results
{
	using System;
	using System.Text;
	using System.Web;
	using System.Web.Mvc;

	using Newtonsoft.Json;

	/// <summary>
	/// The data result.
	/// </summary>
	public class AjaxResult : ActionResult
	{
		 /// <summary>
		 /// Initializes a new instance of the <see cref="AjaxResult"/> class. 
		 /// </summary>
        public AjaxResult()
        {
            this.SerializerSettings = new JsonSerializerSettings();
            this.HttpStatusCode = 200;
        }

        /// <summary>
        /// Gets or sets the content encoding.
        /// </summary>
        public Encoding ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the serializer settings.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        /// Gets or sets the formatting.
        /// </summary>
        public Formatting Formatting { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public object Data { get; protected set; }

        /// <summary>
        /// Gets or sets the http status code.
        /// </summary>
        protected int HttpStatusCode { get; set; }

        /// <summary>
        /// The execute result.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrWhiteSpace(this.ContentType) ? this.ContentType : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;    
            }

            response.StatusCode = this.HttpStatusCode;

            if (this.Data != null)
            {
                var writer = new JsonTextWriter(response.Output) { Formatting = this.Formatting };

                var serializer = JsonSerializer.Create(this.SerializerSettings);
                serializer.Serialize(writer, this.Data);

                writer.Flush();
            }
        }
	}
}