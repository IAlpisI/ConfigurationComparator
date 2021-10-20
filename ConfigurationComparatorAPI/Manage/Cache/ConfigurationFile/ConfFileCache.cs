using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparatorAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public class ConfFileCache : IConfParamCache
    {
        private const string Key = "ConfigurationFiles";
        private const int Days = 1;

        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddConfigurationFileName(ConfigurationFiles configurationFiles)
        {
            _memoryCache.Set(Key, configurationFiles,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(Days)
                }); ;
        }

        public void AddConfigurationValues(FileType fileType, IEnumerable<ConfigurationParameters> conf)
        {
            _memoryCache.Set(fileType, conf,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(Days)
                });
        }

        public bool TryGetConfigurationFileName(out ConfigurationFiles confFiles) =>
                _memoryCache.TryGetValue(Key, out confFiles);

        public bool TryGetConfigurationValues(FileType fileType, out IEnumerable<ConfigurationParameters> confFiles) =>
                _memoryCache.TryGetValue(fileType, out confFiles);
    }
}
