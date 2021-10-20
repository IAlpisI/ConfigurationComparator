using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using System.Collections.Generic;

namespace ConfigurationComparator.Cache.ConfigurationFile
{
    public interface IConfFileCache
    {
        public void AddConfigurationValues(FileType fileType, IEnumerable<ConfigurationParameters> conf);
        public bool TryGetConfigurationValues(FileType fileType, out IEnumerable<ConfigurationParameters> confFiles);
    }
}