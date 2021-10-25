using ConfigurationComparator.ConfigurataionService;
using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Cache;
using ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile;
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
        private readonly IConfigurationFileCache _configurationFileCache;

        public ConfigurationService(IConfigurationFileCache configurationFileCache)
        {
            apiManageConsole = new();
            configurationManager = new ConfigurationManager(apiManageConsole, apiManageConsole);
            _configurationFileCache = configurationFileCache;
        }

        public ComparatorResponseDTO GetFilteredData(FilterDTO filter, ConfigurationFiles confFiles)
        {
            FilterDtoMapper.MapFilterCommands(filter, apiManageConsole);
            configurationManager.InitializeCommands();

            return apiManageConsole
                .GetComparatorParametersData()
                .GetComparatorDTO(GetStringTypeIDs(), confFiles.Source, confFiles.Target);
        }

        public void InitializeData(ConfigurationFiles confFiles)
        {
            var isSourcePresent = _configurationFileCache.TryGetConfigurationValues(CacheKeys.Source, out var sourceData);
            var isTargetPresent = _configurationFileCache.TryGetConfigurationValues(CacheKeys.Target, out var targetData);

            if (isSourcePresent && isTargetPresent)
            {
                configurationManager.SetConfigurationHandler(sourceData, targetData);
            }
            else
            {
                FilterDtoMapper.MapInitializeData(confFiles, apiManageConsole);
                configurationManager.InitializeData(Constants.APIDefaultPath);
            }
        }
        private IEnumerable<ComparatorParameters> GetStringTypeIDs()
        {
            FilterDtoMapper.MapDataWithStringTypeId(apiManageConsole);
            configurationManager.InitializeCommands();

            return apiManageConsole.GetComparatorParametersData();
        }
    }
}
