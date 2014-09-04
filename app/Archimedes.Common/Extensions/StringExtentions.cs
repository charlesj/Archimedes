namespace Archimedes.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The string extentions.  Stolen Shameless from: http://haacked.com/archive/2009/01/14/named-formats-redux.aspx/
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// The format with.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The string cannot be null.
        /// </exception>
        public static string FormatWith(this string format, IFormatProvider provider, object source)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            var values = new List<object>();
            string rewrittenFormat = Regex.Replace(
                format,
                @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                delegate(Match m)
                    {
                        Group startGroup = m.Groups["start"];
                        Group propertyGroup = m.Groups["property"];
                        Group formatGroup = m.Groups["format"];
                        Group endGroup = m.Groups["end"];

                        values.Add((propertyGroup.Value == "0") ? source : source.EvaluateWithDataBinder(propertyGroup.Value));

                        int openings = startGroup.Captures.Count;
                        int closings = endGroup.Captures.Count;

                        return openings > closings || openings % 2 == 0
                                   ? m.Value
                                   : new string('{', openings) + (values.Count - 1) + formatGroup.Value
                                     + new string('}', closings);
                    },
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            return string.Format(provider, rewrittenFormat, values.ToArray());
        }

        /// <summary>
        /// The format with.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string FormatWith(this string format, object source)
        {
            return FormatWith(format, null, source);
        }
    }
}
