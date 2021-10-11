using ConfigurationComparator;
using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Extensions;
using ConfigurationComparatorAPI.Interfaces;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private string Path { get; init; } = Constants.APIDefaultPath;
        private string Extension { get; init; } = Constants.CFGFileExtension;
        private readonly ConfiguratorHandler configuratorHandler;

        public ConfigurationService()
        {
            configuratorHandler = new ConfiguratorHandler();
        }

        public ComparatorResponseDTO GetComparatorResponse(string source, string target)
        {

            var data = HandleFiles(ConfiguratorReader.Decompose(source.GetCurrentPath(Path)),
                                   ConfiguratorReader.Decompose(target.GetCurrentPath(Path)));

            return data.GetComparatorDTO(data, source, target);
        }

        public ComparatorResponseDTO Filter(FilterDTO filter)
        {
            var data = HandleFiles(GetFilePath(filter.SourceFileName),
                                   GetFilePath(filter.TargetFileName));

            var filteredData = data.Filter(filter.Statuses, filter.Id);

            return filteredData.GetComparatorDTO(data, filter.SourceFileName, filter.TargetFileName);
        }

        private List<ComparatorParameters> HandleFiles(string source, string target)
        {
            var sourceData = ConfiguratorReader.Read(source);
            var targetData = ConfiguratorReader.Read(target);

            configuratorHandler.Handle(sourceData, targetData);

            return configuratorHandler.GetComparatorData();
        }

        private string GetFilePath(string file) =>
            file.GetFileWithoutExtention(Extension)
                .GetCurrentPath(Path);
    }
}
