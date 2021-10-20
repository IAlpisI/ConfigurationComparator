using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache.ConfigurationFile
{
    public class ConfFileCache : IConfFileCache
    {
        private const int Days = 1;

        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddConfigurationValues(FileType fileType, IEnumerable<ConfigurationParameters> conf)
        {
            _memoryCache.Set(fileType, conf,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(Days)
                });
        }

        public bool TryGetConfigurationValues(FileType fileType, out IEnumerable<ConfigurationParameters> confFiles) =>
                _memoryCache.TryGetValue(fileType, out confFiles);
    }
}
