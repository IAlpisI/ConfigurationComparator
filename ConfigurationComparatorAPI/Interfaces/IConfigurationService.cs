using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Models;

namespace ConfigurationComparatorAPI.Interfaces
{
    public interface IConfigurationService
    {
        public ComparatorResponseDTO GetFilteredData(FilterDTO filter, ConfigurationFiles confFiles);
    }
}
