namespace Archimedes.Common.Commands
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;

	using Archimedes.Common.Validation;

	public class Response<TResult>
	{
		private Stopwatch stopwatch;

		private TResult result;

		public Response()
		{
			this.stopwatch = new Stopwatch();
		}

		public long ExecutionTime
		{
			get
			{
				return this.stopwatch.ElapsedMilliseconds;
			}
		}

		public TResult Result
		{
			get
			{
				return this.result;
			}
		}

		public Exception Exception { get; set; }

		public string Message { get; set; }

		public ResponseTypes ResultType { get; set; }

		public List<FailureMessage> ValidationErrors { get; set; }

		public void Start()
		{
			this.stopwatch.Start();
		}

		public void End()
		{
			this.stopwatch.Stop();
		}

		public void SetResult(TResult newResult)
		{
			this.result = newResult;
		}
	}
}
