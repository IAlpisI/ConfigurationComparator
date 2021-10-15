using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Models;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Interfaces
{
    public interface IConfigurationService
    {
        public void InitializeData(ConfigurationFiles confFiles);
        public IEnumerable<ComparatorParameters> GetStringTypeIDs();
        public ComparatorResponseDTO Filtered(FilterDTO filter, ConfigurationFiles confFiles);
    }
}
