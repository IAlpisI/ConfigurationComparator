using ConfigurationComparator.Cache.ConfigurationFile;
using ConfigurationComparatorAPI.Models;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public interface IConfParamCache : IConfFileCache
    {
        public void AddConfigurationFileName(ConfigurationFiles configurationFiles);
        public bool TryGetConfigurationFileName(out ConfigurationFiles files);
    }
}