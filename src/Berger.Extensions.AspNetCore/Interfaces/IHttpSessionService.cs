namespace Berger.Extensions.AspNetCore
{
    public interface IHttpSessionService
    {
        void Logoff();
        Guid GetSid();
        string GetIp();
        string GetName();
        Guid GetGroupSid();
        string GetEmail();
        List<string> GetRole();
        Task<bool> Check(string ip, string token);
    }
}