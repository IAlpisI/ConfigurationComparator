using ConfigurationComparatorAPI.Models;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public interface IConfFileCache
    {
        void Add(ConfigurationFiles configurationFiles);
        bool TryGetConfigurationFiles(out ConfigurationFiles files);
    }
}