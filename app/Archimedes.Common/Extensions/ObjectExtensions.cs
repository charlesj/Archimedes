namespace Archimedes.Common.Extensions
{
	using System;
	using System.Reflection;
	using System.Web;
	using System.Web.UI;

	using Newtonsoft.Json;
    
	public static class ObjectExtensions
	{
		public static PropertyInfo[] GetProperties(this object obj)
		{
			return obj.GetType().GetProperties();
		}

		public static string ToJson(this object obj, bool formatted = false)
		{
            if(formatted)
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }

			return JsonConvert.SerializeObject(obj);
		}

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