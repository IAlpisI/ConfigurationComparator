using ConfigurationComparator.ConfigurationVisitor;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache.ConfigurationFile
{
    public class ConfFileCache : IConfFileCache
    {
        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddValue(string fileName, IEnumerable<ConfigurationParameters> conf)
        {
            _memoryCache.Set(fileName,
                conf,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                });
        }

        public bool TryGetConfigurationValue(string fileName, out IEnumerable<ConfigurationParameters> confFiles) =>
                _memoryCache.TryGetValue(fileName, out confFiles);
    }
}
