using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparatorAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public class ConfFileCache : IConfFileNameCache
    {
        private const int Days = 1;

        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddConfigurationFileName(string key, ConfigurationFiles configurationFiles)
        {
            _memoryCache.Set(key, configurationFiles, TimeSpan.FromDays(Days));
        }

        public bool TryGetConfigurationFileName(string key, out ConfigurationFiles confFiles) =>
            _memoryCache.TryGetValue(key, out confFiles);

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void AddConfigurationValues(string key, IEnumerable<ConfigurationParameters> conf)
        {
            _memoryCache.Set(key, conf, TimeSpan.FromDays(Days));
        }

        public bool TryGetConfigurationValues(string key, out IEnumerable<ConfigurationParameters> confFiles) =>
            _memoryCache.TryGetValue(key, out confFiles);
    }
}
