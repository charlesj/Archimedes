namespace Archimedes.Common.Commands
{
	using System;

	using Validation;

	public abstract class BaseCommand<TRequest, TResult> where TRequest : Request
	{
		private readonly IValidateThings valdiator;
		protected BaseCommand(IValidateThings valdiator)
		{
			this.valdiator = valdiator;
			this.SuccessMessage = "Wahoo!";
			this.ErrorMessage = "Unspecific Error Message";
			this.ValidationMessage = "The request is invalid";
			this.UnauthorizedMessage = "You are not authorized to make this request.";
		}

		protected TRequest Request { get; private set; }

		public string SuccessMessage { get; protected set; }
		public string ErrorMessage { get; protected set; }
		public string UnauthorizedMessage { get; protected set; }
		public string ValidationMessage { get; protected set; }

		public Response<TResult> Execute(TRequest request)
		{
			this.Request = request;
			var response = new Response<TResult>();

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
						response.Message = this.SuccessMessage;
					}
					else
					{
						response.ResultType = ResponseTypes.InvalidRequest;
						response.ValidationErrors = validationResult.FailureMessages;
						response.Message = this.ValidationMessage;
					}
				}
				else
				{
					response.ResultType = ResponseTypes.Unauthorized;
					response.Message = this.UnauthorizedMessage;
				}
			}
			catch (Exception exception)
			{
				response.ResultType = ResponseTypes.Error;
				response.Exception = exception;
				response.Message = this.ErrorMessage;
			}

			response.End();
			return response;
		}

		protected abstract TResult Work();

		protected abstract bool Authorize();
	}
}
