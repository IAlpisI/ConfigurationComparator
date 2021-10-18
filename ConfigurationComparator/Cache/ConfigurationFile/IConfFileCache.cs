using ConfigurationComparator.ConfigurationVisitor;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache.ConfigurationFile
{
    public interface IConfFileCache
    {
        public void AddValue(string fileName, IEnumerable<ConfigurationParameters> conf);
        public bool TryGetConfigurationValue(string fileName, out IEnumerable<ConfigurationParameters> confFiles);
    }
}