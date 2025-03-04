﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Berger.Extensions.Abstractions;
using Microsoft.AspNetCore.Http.Features;

namespace Berger.Extensions.AspNetCore
{
    public class HttpSessionService : IHttpSessionService
    {
        private readonly IHttpContextAccessor _acessor;
        public HttpSessionService(IHttpContextAccessor acessor)
        {
            this._acessor = acessor ?? throw new ArgumentNullException(nameof(acessor));
        }
        public Guid GetGroupSid()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid);

            return Guid.Parse(claim.Value);
        }
        public Guid GetSid()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.Sid);

            return Guid.Parse(claim.Value);
        }
        public string GetName()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.Name);

            return claim != null ? claim.Value : string.Empty;
        }
        public string GetEmail()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.Email);

            return claim != null ? claim.Value : string.Empty;
        }
        public List<string> GetRole()
        {
            var claim = _acessor.HttpContext.User.FindAll(ClaimTypes.Role);

            return claim != null ? claim.Select(c => c.Value).ToList() : new List<string>();
        }
        public string GetIp()
        {
            var address = _acessor.HttpContext.Features.Get<IHttpConnectionFeature>();

            if (address != null)
                return address.RemoteIpAddress.ToString();
            else
                return string.Empty;
        }
        public void Logoff()
        {
            var ip = GetIp();

            _acessor.HttpContext.Session.Remove(Standards.Token);
        }
        private async Task<bool> CheckIp(Guid sessionId, string ip)
        {
            //if (session.IpAddress != ip && session.IpAddress != "::1")
            //{
            //    await Revoke(session);

            //    return false;
            //}

            return true;
        }
        private async Task Revoke(Guid id)
        {
            //session.Revoke();
            //await UpdateAsync(session);
            //return session;
        }
        public async Task<bool> Check(string ip, string token)
        {
            //var session = _repository.FirstOrDefault(e => e.Token == token);

            //return await Check(session, ip);
            return true;
        }
    }
}