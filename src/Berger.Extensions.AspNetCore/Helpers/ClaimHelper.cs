using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Berger.Extensions.AspNetCore
{
    public static class ClaimHelper
    {
        public static Guid? Get(this ClaimsPrincipal claims, string claimType)
        {
            var asset = claims.FindFirst(claimType);

            if (asset is not null)
            {
                if (Guid.TryParse(asset.Value, out Guid id))
                    return id;
            }

            return null;
        }
        public static string GetClaims(this HttpContext context, string claim)
        {
            return GetClaims(context.User, claim);
        }
        public static string GetClaims(this AuthorizationHandlerContext context, string claim)
        {
            return GetClaims(context.User, claim);
        }
        public static string GetClaims(this ClaimsPrincipal claimPrincipal, string claim)
        {
            return claimPrincipal.FindFirstValue(claim);
        }
        public static bool IsInRole(this ClaimsPrincipal claims, string role) => claims.IsInRole(role);
        public static bool IsNotInRole(this ClaimsPrincipal claims, string role) => !claims.IsInRole(role);
        public static bool IsOwner<TDestination>(this TDestination entity, ClaimsPrincipal claims)
        {
            throw new NotImplementedException();
        }
        public static bool IsAutenticated(this ClaimsPrincipal claims)
        {
            var userId = claims.Get(ClaimTypes.Sid) ?? Guid.Empty;

            return userId != Guid.Empty;
        }
        public static bool IsInGroup(this ClaimsPrincipal claims)
        {
            var groupSid = claims.Get(ClaimTypes.GroupSid) ?? Guid.Empty;

            return groupSid != Guid.Empty;
        }
    }
}