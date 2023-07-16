using System.Web;

namespace Moralis.Net.Core.Utilities
{
    public class MoralisHelper
    {
        const string VERSION = "v2";
        const string BASE_URL = "https://deep-index.moralis.io/api/";

        internal static Uri GetBaseUrl()
        {
            return new Uri($"{BASE_URL}{VERSION}");
        }

        internal static string GetRequestUrl(string url, string version = "")
        {
            version = string.IsNullOrEmpty(version) ? VERSION : version;
            return $"{BASE_URL}{version}{url}";
        }

        internal static string CreateQueryString(Dictionary<string, string>? parameters)
        {
            parameters ??= new Dictionary<string, string>();
            return $"?{string.Join("&", parameters.Where(p => !string.IsNullOrEmpty(p.Value))
                .Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"))}";
        }
    }
}
