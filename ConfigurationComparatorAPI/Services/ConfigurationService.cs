using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Console;
using ConfigurationComparatorAPI.Manage.Mappers;
using ConfigurationComparatorAPI.Models;
using System.Collections.Generic;

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

        public ComparatorResponseDTO Filtered(FilterDTO filter, ConfigurationFiles confFiles)
        {
            FilterDtoMapper.MapFilterCommands(filter, apiManageConsole);
            configurationManager.InitializeCommands();
            var filteredData = apiManageConsole.GetComparatorParametersData();

            return filteredData.GetComparatorDTO(GetStringTypeIDs(), confFiles.Source, confFiles.Target);
        }

        public IEnumerable<ComparatorParameters> GetStringTypeIDs()
        {
            FilterDtoMapper.MapDataWithStringTypeId(apiManageConsole);
            configurationManager.InitializeCommands();
            return apiManageConsole.GetComparatorParametersData();
        }

        public void InitializeData(ConfigurationFiles confFiles)
        {
            FilterDtoMapper.MapInitializeData(confFiles, apiManageConsole);
            configurationManager.InitializeData(Constants.APIDefaultPath);
        }
    }
}
