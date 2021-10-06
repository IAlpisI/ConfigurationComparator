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

        public ComparatorResponseDTO GetResponse(IFormFile sourceFile, IFormFile targetFile)
        {
            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(sourceFile.FileName.GetCurrentPath(Path)));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(targetFile.FileName.GetCurrentPath(Path)));

            configuratorHandler.Handle(sourceData, targetData);

            return new ComparatorResponseDTO
            {
                SourceFileName = sourceFile.FileName,
                TargetFileName = targetFile.FileName,
                ComparatorParameters = configuratorHandler.GetComparatorData()
            };
        }

        public ComparatorResponseDTO GetFilteredById(FilterByIdDTO filterById)
        {
            HandleFiles(filterById.SourceFileName, filterById.TargetFileName);

            var data = configuratorHandler.GetComparatorData().FilterById(filterById.Id);

            return new ComparatorResponseDTO
            {
                SourceFileName = filterById.SourceFileName,
                TargetFileName = filterById.TargetFileName,
                ComparatorParameters = data,
            };
        }

        public ComparatorResponseDTO GetFilteredByStatus(FilterByStatusDTO filterByStatus)
        {
            HandleFiles(filterByStatus.SourceFileName, filterByStatus.TargetFileName);

            var data = configuratorHandler.GetComparatorData().FilterByStatus(filterByStatus.Status);

            return new ComparatorResponseDTO
            {
                SourceFileName = filterByStatus.SourceFileName,
                TargetFileName = filterByStatus.TargetFileName,
                ComparatorParameters = data,
            };
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
