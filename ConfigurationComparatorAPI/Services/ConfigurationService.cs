using ConfigurationComparator;
using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Extensions;
using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Extensions;
using ConfigurationComparatorAPI.Manage.Files;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ConfigurationComparatorAPI.Services
{
    public class ConfigurationService
    {
        private string Path { get; set; }
        private string Extension { get; set; }
        private readonly ConfiguratorHandler configuratorHandler;

        public ConfigurationService(string path, string extension)
        {
            Path = path;
            Extension= extension;
            configuratorHandler = new ConfiguratorHandler();
        }

        public bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile)
        {
            if (sourceFile.FileName.FileExtentionMatch(Extension) &&
                targetFile.FileName.FileExtentionMatch(Extension))
            {
                ConfigurationWriter.Write(sourceFile, Path);
                ConfigurationWriter.Write(targetFile, Path);

                return true;
            }
            return false;
        }

        public ComparatorResponseDTO GetResponse(string source, string target)
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

        public bool ValidateFiles(string source, string target) =>
            Extension.CheckFile(Path, source) && Extension.CheckFile(Path, target);
    }
}
