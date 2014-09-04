namespace Archimedes.Common.Extensions
{
	using System;
	using System.Reflection;
	using System.Web;
	using System.Web.UI;

	using Newtonsoft.Json;

	/// <summary>
	/// The object extensions contains useful extensions on objects.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Gets all the properties on the object.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		/// <returns>
		/// An array of all the properties.
		/// </returns>
		public static PropertyInfo[] GetProperties(this object obj)
		{
			return obj.GetType().GetProperties();
		}

		/// <summary>
		/// Serializes the object into json.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public static string ToJson(this object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

	    /// <summary>
	    /// The eval.
	    /// </summary>
	    /// <param name="source">
	    /// The source.
	    /// </param>
	    /// <param name="expression">
	    /// The expression.
	    /// </param>
	    /// <returns>
	    /// The <see cref="object"/>.
	    /// </returns>
	    /// <exception cref="FormatException">
	    /// If it's invalid.
	    /// </exception>
	    public static object EvaluateWithDataBinder(this object source, string expression)
		{
			try
			{
				return DataBinder.Eval(source, expression);
			}
			catch (HttpException e)
			{
				throw new FormatException(null, e);
			}
		}
	}
}