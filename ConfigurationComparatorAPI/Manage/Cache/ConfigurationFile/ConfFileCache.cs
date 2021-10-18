﻿using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparatorAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public class ConfFileCache : IConfParamCache
    {
        private const string Key = "ConfigurationFiles";
        private readonly IMemoryCache _memoryCache;
        public ConfFileCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddParameters(ConfigurationFiles configurationFiles)
        {
            _memoryCache.Set(Key,
                configurationFiles,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                }); ;
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

        public bool TryGetConfigurationParams(out ConfigurationFiles confFiles) =>
                _memoryCache.TryGetValue(Key, out confFiles);

        public bool TryGetConfigurationValue(string fileName, out IEnumerable<ConfigurationParameters> confFiles) =>
                _memoryCache.TryGetValue(fileName, out confFiles);
    }
}
