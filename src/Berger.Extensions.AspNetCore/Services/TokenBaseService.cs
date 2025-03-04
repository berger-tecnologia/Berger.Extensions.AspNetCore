﻿using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Berger.Extensions.AspNetCore
{
    public class TokenBaseService
    {
        public DateTime Calculate(int expiration)
        {
            return DateTime.UtcNow.AddHours(expiration);
        }
        public SigningCredentials CreateSigningCredentials(string secret)
        {
            var key = CreateSymmetricSecurityKey(secret);

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        }        
        public SymmetricSecurityKey CreateSymmetricSecurityKey(string secret)
        {
            var bytes = Encoding.ASCII.GetBytes(secret);

            return new SymmetricSecurityKey(bytes);
        }
        public static ClaimsIdentity CreateClaims(string name, string email, string role)
        {
            return new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                });
        }
        public static ClaimsIdentity CreateClaims(string email, string role)
        {
            return new ClaimsIdentity
            (
                Create()
            );

            Claim[] Create()
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                };

                claims.Add(new Claim(ClaimTypes.Role, role));

                return claims.ToArray();
            }
        }
    }
}