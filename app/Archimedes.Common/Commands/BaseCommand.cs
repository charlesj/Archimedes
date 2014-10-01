namespace Archimedes.Common.Commands
{
	using System;

	using Archimedes.Common.Validation;

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
		/// The valdiator.
		/// </summary>
		private readonly IValidateThings valdiator;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseCommand{TRequest,TResult}"/> class.
		/// </summary>
		/// <param name="valdiator">
		/// The valdiator.
		/// </param>
		protected BaseCommand(IValidateThings valdiator)
		{
			this.valdiator = valdiator;
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
				if (this.Authorize())
				{
					var validationResult = this.valdiator.CheckValidation(request);
					if (validationResult.IsValid)
					{
						response.SetResult(this.Work());
						response.ResultType = ResponseTypes.Success;
					}
					else
					{
						response.ResultType = ResponseTypes.InvalidRequest;
						response.ValidationErrors = validationResult.FailureMessages;
					}
				}
				else
				{
					response.ResultType = ResponseTypes.Unauthorized;
				}
			}
			catch (Exception exception)
			{
				response.ResultType = ResponseTypes.Error;
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

		/// <summary>
		/// Runs any authorization check required.
		/// </summary>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		protected abstract bool Authorize();
	}
}