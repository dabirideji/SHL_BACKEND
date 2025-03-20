using Microsoft.Extensions.Caching.Memory;
using SHL.Application.IManagers;
using System.Collections.Concurrent;

namespace SHL.Infrastructure.Managers
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ConcurrentDictionary<string, bool> _cachedKeys;

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cachedKeys = new ConcurrentDictionary<string, bool>();
        }

        public async Task<T?> GetAsync<T>(string key) where T : class
        {
            if (_memoryCache.TryGetValue(key, out T cacheEntry))
            {
                return cacheEntry;
            }
            return null;
        }
        public async Task SetAsync<T>(string key, T item, TimeSpan expiration) where T : class
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration,
                PostEvictionCallbacks =
        {
            new PostEvictionCallbackRegistration
            {
                EvictionCallback = (evictedKey, value, reason, state) =>
                {
                    if (evictedKey is string keyString)
                    {
                        _cachedKeys.TryRemove(keyString, out _);
                    }
                }
            }
        }
            };

            _memoryCache.Set(key, item, cacheEntryOptions);
            _cachedKeys.TryAdd(key, true);
        }

        public async Task ClearCache()
        {
            foreach (var key in _cachedKeys.Keys)
            {
                _memoryCache.Remove(key);
            }
            _cachedKeys.Clear();
        }

        public async Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            _cachedKeys.TryRemove(key, out _);
        }
    }
}
