using Microsoft.AspNetCore.Http;
using SHL.Application.Interfaces;

namespace SHL.Application.Services
{


public class HttpContextService : IHttpContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public void Set(string key, object value)
    {
        if (_httpContextAccessor.HttpContext == null) return;

        _httpContextAccessor.HttpContext.Items[key] = value;
    }

    public T Get<T>(string key)
    {
        if (_httpContextAccessor.HttpContext == null || !_httpContextAccessor.HttpContext.Items.ContainsKey(key))
            return default;

        return (T)_httpContextAccessor.HttpContext.Items[key];
    }

    public void Remove(string key)
    {
        if (_httpContextAccessor.HttpContext == null) return;

        _httpContextAccessor.HttpContext.Items.Remove(key);
    }
}


}
