namespace SHL.Application.IManagers
{
    public interface ICacheManager
    {
        Task<T?> GetAsync<T>(string key) where T : class;
        Task SetAsync<T>(string key, T item, TimeSpan expiration) where T : class;
        Task RemoveAsync(string key);
        Task ClearCache();
    }
}
