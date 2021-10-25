using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparatorAPI.Models;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile
{
    public interface IConfigurationFileCache
    {
        public void AddConfigurationValues(string key, IEnumerable<ConfigurationParameters> conf);
        public bool TryGetConfigurationValues(string key, out IEnumerable<ConfigurationParameters> confFiles);
        public void AddConfigurationFileNames(string key, ConfigurationFiles configurationFiles);
        public bool TryGetConfigurationFileNames(string key, out ConfigurationFiles files);
        public void Remove(string key);
    }
}