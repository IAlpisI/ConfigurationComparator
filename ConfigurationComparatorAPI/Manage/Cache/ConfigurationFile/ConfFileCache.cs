using ConfigurationComparatorAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public class ConfFileCache : IConfFileCache
    {
        private const string Key = "Files";
        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(ConfigurationFiles configurationFiles)
        {
            _memoryCache.Set(Key,
                configurationFiles,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                }); ;
        }

        public bool TryGetConfigurationFiles(out ConfigurationFiles confFiles) =>
                _memoryCache.TryGetValue(Key, out confFiles);
    }
}
