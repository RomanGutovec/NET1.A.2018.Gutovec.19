using System;
using System.Collections.Generic;
using System.Linq;
using XmlLib.Interfaces;

namespace XmlLib.Helpers
{
    /// <summary>
    /// Represents opportunity to convert string into Url
    /// </summary>
    public class ToUrlParser : IParser<string, Url>
    {
        /// <summary>
        /// Convert string into Url
        /// </summary>
        /// <param name="url">String which represents simple url address</param>
        /// <returns>Converted into url string</returns>
        public Url Parse(string url)
        {
            Uri uri = new Uri(url);

            string hostpart = uri.DnsSafeHost;

            string[] pathsegments = uri.LocalPath.Split('/').Where(n => !string.IsNullOrWhiteSpace(n)).ToArray();

            string querystring = uri.Query;

            return new Url() { Host = hostpart, Segments = pathsegments.ToList<string>(), Parameters = ParseQueryString(querystring) };
        }

        private Dictionary<string, string> ParseQueryString(string query)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            string[] querySegments = query.Split('&');
            foreach (string segment in querySegments)
            {
                string[] parts = segment.Split('=');
                if (parts.Length > 1)
                {
                    string key = parts[0].Trim(new char[] { '?', ' ' });
                    string val = parts[1].Trim();

                    queryParameters.Add(key, val);
                }
            }

            return queryParameters;
        }
    }
}
