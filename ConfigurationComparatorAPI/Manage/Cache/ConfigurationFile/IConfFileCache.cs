using ConfigurationComparatorAPI.Models;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public interface IConfFileCache
    {
        public void Add(ConfigurationFiles configurationFiles);
        public bool TryGetConfigurationFiles(out ConfigurationFiles files);
    }
}