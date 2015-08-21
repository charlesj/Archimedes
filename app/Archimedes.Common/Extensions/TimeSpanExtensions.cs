namespace Archimedes.Common.Extensions
{
	using System;

	public static class TimeSpanExtensions
	{
		public static int InMilliseconds(this TimeSpan ts)
		{
			return (int)ts.TotalMilliseconds;
		}

		public static DateTime Ago(this TimeSpan ts)
		{
			return DateTime.Now - ts;
		}

		public static DateTime FromNow(this TimeSpan ts)
		{
			return DateTime.Now + ts;
		}
	}
}