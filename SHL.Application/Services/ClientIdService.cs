using Microsoft.AspNetCore.Http;
public class ClientIdService : IClientIdService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClientIdService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetClientId()
    {
        var clientId = _httpContextAccessor.HttpContext?.Request.Headers["X-CLIENT-ID"].FirstOrDefault();

        return clientId ?? "ADMIN";
    }
}
