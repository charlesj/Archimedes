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
		}

		protected TRequest Request { get; private set; }

		public Response<TResult> Execute(TRequest request)
		{
			this.Request = request;
			var response = new Response<TResult>();

			response.Start();
			try
			{
				var validationResult = this.valdiator.CheckValidation(request);
				if (validationResult.IsValid)
				{
					if (this.Authorize())
					{
						response.SetResult(this.Work());
						response.ResultType = ResponseTypes.Success;
					}
					else
					{
						response.ResultType = ResponseTypes.Unauthorized;
					}
				}
				else
				{
					response.ResultType = ResponseTypes.InvalidRequest;
					response.ValidationErrors = validationResult.FailureMessages;
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

		protected abstract TResult Work();

		protected abstract bool Authorize();
	}
}