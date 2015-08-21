namespace Archimedes.Common.Extensions
{
	using System;

	public static class IntExtensions
	{
		public static TimeSpan Days(this int i)
		{
			return new TimeSpan(i, 0, 0, 0);
		}

		public static TimeSpan Hours(this int i)
		{
			return new TimeSpan(0, i, 0, 0);
		}

		public static TimeSpan Minutes(this int i)
		{
			return new TimeSpan(0, 0, i, 0);
		}

		public static TimeSpan Seconds(this int i)
		{
			return new TimeSpan(0, 0, 0, i);
		}

		public static TimeSpan Milliseconds(this int i)
		{
			return new TimeSpan(0, 0, 0, 0, i);
		}

		public static string Pluralize(this int i, string singular, string plural)
		{
			if (i == 1 || i == -1)
			{
				return singular;
			}

			return plural;
		}
	}
}