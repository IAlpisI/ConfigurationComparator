using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparatorAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public class ConfigurationFileCache : IConfigurationFileCache
    {
        private const int Days = 1;

        private readonly IMemoryCache _memoryCache;
        public ConfigurationFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddConfigurationFileNames(string key, ConfigurationFiles configurationFiles)
        {
            _memoryCache.Set(key, configurationFiles, TimeSpan.FromDays(Days));
        }

        public bool TryGetConfigurationFileNames(string key, out ConfigurationFiles confFiles) =>
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
