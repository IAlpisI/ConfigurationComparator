using ConfigurationComparator.ConfigurationVisitor;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache
{
    public class ConfFileCache : IConfFileCache
    {
        private const int Days = 1;

        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddConfigurationValues(string key, IEnumerable<ConfigurationParameters> conf)
        {
            _memoryCache.Set(key, conf, TimeSpan.FromDays(Days));
        }

        public bool TryGetConfigurationValues(string key, out IEnumerable<ConfigurationParameters> confFiles) =>
                _memoryCache.TryGetValue(key, out confFiles);
    }
}
