using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Imade.Speedware.Web.Helpers
{
    public static class Url
    {

        public static string NormalizeFileName(this string filename)
        {
            StringBuilder stringBuilder = new StringBuilder(System.Net.WebUtility.UrlDecode(filename).ToLower().Trim());
            char[] invalidFileChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidFileChars)
            {
                stringBuilder.Replace(c, '-');
            }

            foreach (KeyValuePair<string, string> replacement in GetReplacements())
            {
                stringBuilder.Replace(replacement.Key, replacement.Value);
            }
            return stringBuilder.ToString();
        }

        private static IDictionary<string, string> GetReplacements()
        {
            Dictionary<string, string> strs = new Dictionary<string, string>();
            ((IDictionary<string, string>)strs).Add("ø", "oe");
            ((IDictionary<string, string>)strs).Add("æ", "ae");
            ((IDictionary<string, string>)strs).Add("å", "aa");
            ((IDictionary<string, string>)strs).Add("ö", "oe");
            ((IDictionary<string, string>)strs).Add("ä", "ae");
            ((IDictionary<string, string>)strs).Add("ü", "ue");
            ((IDictionary<string, string>)strs).Add("ß", "ss");
            ((IDictionary<string, string>)strs).Add(" ", "-");
            //((IDictionary<string, string>)strs).Add("\"", "");
            ((IDictionary<string, string>)strs).Add("&", "");
            //((IDictionary<string, string>)strs).Add("?", "");
            ((IDictionary<string, string>)strs).Add("%", "");
            //((IDictionary<string, string>)strs).Add(":", "");
            //((IDictionary<string, string>)strs).Add("<", "");
            //((IDictionary<string, string>)strs).Add(">", "");
            //((IDictionary<string, string>)strs).Add("/", "");
            //((IDictionary<string, string>)strs).Add("|", "");
            ((IDictionary<string, string>)strs).Add("+", "");
            ((IDictionary<string, string>)strs).Add("*", "");
            ((IDictionary<string, string>)strs).Add("{", "");
            ((IDictionary<string, string>)strs).Add("}", "");
            ((IDictionary<string, string>)strs).Add("#", "");
            //((IDictionary<string, string>)strs).Add("\\", "");
            ((IDictionary<string, string>)strs).Add("¢", "");
            ((IDictionary<string, string>)strs).Add("£", "");
            ((IDictionary<string, string>)strs).Add("¥", "");
            ((IDictionary<string, string>)strs).Add("€", "");
            ((IDictionary<string, string>)strs).Add("§", "");
            ((IDictionary<string, string>)strs).Add("©", "");
            ((IDictionary<string, string>)strs).Add("®", "");
            ((IDictionary<string, string>)strs).Add("™", "");
            return strs;
        }

        private static string ReplaceQueryString(QueryString queryString, string parameterKey, string newValue, bool addIfNotFound = true)
        {
            if (!queryString.HasValue && addIfNotFound)
            {
                queryString = QueryString.Create(parameterKey, newValue);
                //queryString.Add(parameterKey, newValue);

            }
            //else {
            //    return string.Empty;
            //}

            var q = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(queryString.ToString());

            if (!q.ContainsKey(parameterKey))
            {
                q.Add(parameterKey, newValue);
                var qb = new QueryBuilder(q);
                return qb.ToQueryString().ToString();
                //return queryString.ToString();
            }
            else
            {
                q.Remove(parameterKey);
                q.Add(parameterKey, newValue);
                var qb = new QueryBuilder(q);
                return qb.ToQueryString().ToString();
            }
        }
        public static string ReplaceQueryStringParameter(this string url, string parameterKey, string newValue, bool addIfNotFound = true)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }
            try
            {
                var u = new Uri(url);
                var uribuilder = new UriBuilder();
                return u.LocalPath + ReplaceQueryString(new QueryString(u.Query.ToString()), parameterKey, newValue, addIfNotFound);
            }
            catch
            {
                return url;
            }
        }

        public static T GetQueryStringValue<T>(this Microsoft.AspNetCore.Http.HttpRequest request, string key)
        {
            if (request is null)
            {
                return default;
            }
            if (request.Query.TryGetValue(key, out var value))
            {
                var first = value.FirstOrDefault();
                var res = Umbraco.Extensions.ObjectExtensions.TryConvertTo<T>(first);
                if (res.Success)
                {
                    return res.Result;
                }
                return default;
            }
            return default;
        }

    }
}
