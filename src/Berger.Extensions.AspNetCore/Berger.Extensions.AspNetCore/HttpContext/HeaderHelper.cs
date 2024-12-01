using Microsoft.AspNetCore.Http;

namespace Berger.Extensions.AspNetCore
{
    public static class HeaderHelper
    {
        public static string GetValue(this IHeaderDictionary headers, string key)
        {
            return headers[key].ToString();
        }
    }
}