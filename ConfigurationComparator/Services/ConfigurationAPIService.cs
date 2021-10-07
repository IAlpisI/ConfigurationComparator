using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Dtos;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.OperateFiles;
using ConfigurationComparatorAPI.Dtos;
using Microsoft.AspNetCore.Http;

namespace ConfigurationComparator.Services
{
    public class ConfigurationAPIService
    {
        private string Path { get; set; }
        private string Extension { get; set; }
        private readonly ConfiguratorHandler configuratorHandler;

        public ConfigurationAPIService(string path, string extension)
        {
            Path = path;
            Extension= extension;
            configuratorHandler = new ConfiguratorHandler();
        }

        public bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile)
        {
            if (sourceFile.FileName.CheckFileExtention(Extension) &&
                targetFile.FileName.CheckFileExtention(Extension))
            {
                ConfigurationWriter.Write(sourceFile, Path);
                ConfigurationWriter.Write(targetFile, Path);

                return true;
            }

            return false;
        }

        public ComparatorResponseDTO GetResponse(string source, string target)
        {
            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(source.GetCurrentPath(Path)));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(target.GetCurrentPath(Path)));

            configuratorHandler.Handle(sourceData, targetData);

            var data = configuratorHandler.GetComparatorData();

            return data.GetComparatorDTO(data, source, target);
        }

        public ComparatorResponseDTO Filter(FilterDTO filter)
        {
            HandleFiles(filter.SourceFileName, filter.TargetFileName);

            var data = configuratorHandler.GetComparatorData();
            var filteredData = data.Filter(filter.Statuses, filter.Id);

            return filteredData.GetComparatorDTO(data, filter.SourceFileName, filter.TargetFileName);
        }

        private void HandleFiles(string source, string target)
        {
            var sourceData = ConfiguratorReader.Read(FilePath(source));
            var targetData = ConfiguratorReader.Read(FilePath(target));

            configuratorHandler.Handle(sourceData, targetData);
        }

        private string FilePath(string file) =>
            file.GetFileWithoutExtention(Extension)
                .GetCurrentPath(Path);

        public bool FilesArePresent(string source, string target) =>
            Extension.CheckFile(Path, source) && Extension.CheckFile(Path, target);
    }
}
