using ConfigurationComparator.ConfigurationVisitor;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache
{
    public interface IConfFileCache
    {
        public void AddConfigurationValues(string key, IEnumerable<ConfigurationParameters> conf);
        public bool TryGetConfigurationValues(string key, out IEnumerable<ConfigurationParameters> confFiles);
    }
}