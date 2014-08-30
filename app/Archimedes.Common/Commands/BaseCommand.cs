namespace Archimedes.Common.Commands
{
	using System;

	/// <summary>
	/// The base data controller.
	/// </summary>
	/// <typeparam name="TRequest">
	/// The Request Object
	/// </typeparam>
	/// <typeparam name="TResult">
	/// The type of the result.
	/// </typeparam>
	public abstract class BaseCommand<TRequest, TResult> where TRequest : Request
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseCommand{TRequest,TResult}"/> class.
		/// </summary>
		protected BaseCommand()
		{
			this.SuccessMessage = "Wahoo!";
			this.ErrorMessage = "Unspecific Error Message";
		}

		/// <summary>
		/// Gets the request.
		/// </summary>
		protected TRequest Request { get; private set; }

		/// <summary>
		/// Gets or sets A message suitable to displaying to a user on success.
		/// </summary>
		public string SuccessMessage { get; protected set; }

		/// <summary>
		/// Gets or sets A message suitable to displaying to a user on success.
		/// </summary>
		public string ErrorMessage { get; protected set; }

		/// <summary>
		/// Executes the command
		/// </summary>
		/// <param name="request">
		/// The request.
		/// </param>
		/// <returns>
		/// The <see cref="TResponse"/>.
		/// </returns>
		public Response<TResult> Execute(TRequest request)
		{
			this.Request = request;
			var response = new Response<TResult>();
			response.SuccessMessage = this.SuccessMessage;
			response.ErrorMessage = this.ErrorMessage;
			response.Start();
			try
			{
				response.SetResult(this.Work());
				response.Success = true;
			}
			catch (Exception exception)
			{
				response.Success = false;
				response.Exception = exception;
			}

			response.End();
			return response;
		}

		/// <summary>
		/// The do Work.
		/// </summary>
		/// <returns>
		/// The <see cref="TResult"/>.
		/// </returns>
		protected abstract TResult Work();
	}
}