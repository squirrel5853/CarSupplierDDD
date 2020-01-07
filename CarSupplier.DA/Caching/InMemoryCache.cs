using Microsoft.Extensions.Caching.Memory;
using System;

namespace CarSupplier.DA.Caching
{
    public class InMemoryCache<T> : IDisposable
    {
        public const int DEFAULT_MEMORY_EXPIRATION_TIME_IN_SECONDS = 2 * 60;

        private IMemoryCache _memoryCache;

        private int AbsoluteCacheExpiryTimeInSeconds { get; }

        private static object _padlock = new object();

        public static InMemoryCache<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new InMemoryCache<T>(DEFAULT_MEMORY_EXPIRATION_TIME_IN_SECONDS);
                        }
                    }
                }
                return _instance;
            }
        }
        private static InMemoryCache<T> _instance;

        protected InMemoryCache(int absoluteExpiryTimeInSeconds)
        {
            MemoryCacheOptions memoryCacheOptions = new MemoryCacheOptions();
            memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(3);
            _memoryCache = new MemoryCache(memoryCacheOptions);

            AbsoluteCacheExpiryTimeInSeconds = absoluteExpiryTimeInSeconds;
        }

        public T Get(string key)
        {
            T cacheItem = default(T);
            lock (_padlock)
            {
                _memoryCache.TryGetValue(key, out cacheItem);
            }
            return cacheItem;
        }

        public void Put(string key, T item)
        {
            lock (_padlock)
            {
                _memoryCache.Set(key, item, TimeSpan.FromSeconds(AbsoluteCacheExpiryTimeInSeconds));
            }
        }

        public void Remove(string key)
        {
            lock (_padlock)
            {
                _memoryCache.Remove(key);
            }
        }

        public void Dispose()
        {
            _memoryCache.Dispose();
        }
    }
}
