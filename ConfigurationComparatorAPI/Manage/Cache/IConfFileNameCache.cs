using ConfigurationComparator.Cache;
using ConfigurationComparatorAPI.Models;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public interface IConfFileNameCache : IConfFileCache
    {
        public void AddConfigurationFileName(string key, ConfigurationFiles configurationFiles);
        public bool TryGetConfigurationFileName(string key, out ConfigurationFiles files);
        public void Remove(string key);
    }
}