using ConfigurationComparator.Cache.ConfigurationFile;
using ConfigurationComparatorAPI.Models;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public interface IConfParamCache : IConfFileCache
    {
        public void AddParameters(ConfigurationFiles configurationFiles);
        public bool TryGetConfigurationParams(out ConfigurationFiles files);
    }
}