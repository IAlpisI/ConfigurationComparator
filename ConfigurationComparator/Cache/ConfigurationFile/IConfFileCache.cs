using ConfigurationComparator.ConfigurationVisitor;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache.ConfigurationFile
{
    public interface IConfFileCache
    {
        public void AddConfigurationValues(string fileName, IEnumerable<ConfigurationParameters> conf);
        public bool TryGetConfigurationValues(string fileName, out IEnumerable<ConfigurationParameters> confFiles);
    }
}