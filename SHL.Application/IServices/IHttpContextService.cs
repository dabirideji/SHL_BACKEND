namespace SHL.Application.Interfaces
{
    public interface IHttpContextService
{
    void Set(string key, object value);
    T Get<T>(string key);
    void Remove(string key);
}
}
