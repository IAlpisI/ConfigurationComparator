using ConfigurationComparatorAPI.Dtos;

namespace ConfigurationComparatorAPI.Interfaces
{
    public interface IConfigurationService
    {
        ComparatorResponseDTO GetComparatorResponse(string source, string target);
        ComparatorResponseDTO Filter(FilterDTO filter);
    }
}
