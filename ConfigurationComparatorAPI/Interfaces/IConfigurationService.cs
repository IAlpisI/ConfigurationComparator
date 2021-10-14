using ConfigurationComparatorAPI.Dtos;

namespace ConfigurationComparatorAPI.Interfaces
{
    public interface IConfigurationService
    {
        ComparatorResponseDTO Filter(FilterDTO filter);
    }
}
