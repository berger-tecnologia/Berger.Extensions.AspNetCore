using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Berger.Extensions.Abstractions;

namespace Berger.Extensions.AspNetCore
{
    public static class HttpContextHelper
    {
        public static string GetIp(this HttpContext context)
        {
            return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public static string GetIp(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public static string GetHeader(this IHttpContextAccessor accessor, string header)
        {
            return accessor.HttpContext.Request.Headers[header].ToString();
        }
        public static string GetHeader(this HttpContext context, string header)
        {
            return context.Request.Headers[header].ToString();
        }
        public static string GetBearer(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext.GetBearer();
        }
        public static Guid CreateDevice(this IHttpContextAccessor accessor, Guid deviceId)
        {
            throw new NotImplementedException();
        }
        public static string GetBearer(this HttpContext context)
        {
            var token = context.GetHeader(HeaderNames.Authorization);

            if (!string.IsNullOrEmpty(token))
                return token.Replace(Standards.Bearer, string.Empty);

            return string.Empty;
        }
    }
}