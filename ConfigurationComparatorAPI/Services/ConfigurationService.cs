using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Console;
using ConfigurationComparatorAPI.Manage.Mappers;

namespace ConfigurationComparatorAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ApiEmulateConsole apiManageConsole;
        private readonly ConfigurationManager configurationManager;

        public ConfigurationService()
        {
            apiManageConsole = new();
            configurationManager = new ConfigurationManager(apiManageConsole, apiManageConsole);
        }

        public ComparatorResponseDTO Filter(FilterDTO filter)
        {
            FilterDtoMapper.MapFilterCommands(filter, apiManageConsole);
            configurationManager.InitializeData(Constants.APIDefaultPath);
            configurationManager.InitializeCommands();
            var filteredData = apiManageConsole.GetComparatorParametersData();

            FilterDtoMapper.MapDataWithStringTypeId(apiManageConsole);
            configurationManager.InitializeCommands();
            var strinTypeIdData = apiManageConsole.GetComparatorParametersData();

            return filteredData.GetComparatorDTO(strinTypeIdData, filter.SourceFileName, filter.TargetFileName);
        }
    }
}
