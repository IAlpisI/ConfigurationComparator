using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Dtos;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;
using ConfigurationComparator.OperateFiles;
using ConfigurationComparatorAPI.Dtos;
using Microsoft.AspNetCore.Http;

namespace ConfigurationComparator.ConfigurataionService
{
    public class ConfigurationService
    {
        private readonly CommandHandler commandHandler;
        private readonly LocateFiles locateFiles;
        private readonly ConfiguratorHandler configuratorHandler;
        public ConfigurationService(IMessageWriter messageWriter, IMessageReader messageReader)
        {
            commandHandler = new CommandHandler(messageWriter, messageReader);
            locateFiles = new LocateFiles(messageWriter, messageReader);
            configuratorHandler = new ConfiguratorHandler();
        }

        public ConfigurationService()
        {
            configuratorHandler = new ConfiguratorHandler();
        }

        public void InitializeData()
        {
            locateFiles.LookForFile(FileType.Target, Constants.CFGFileExtension);
            locateFiles.LookForFile(FileType.Source, Constants.CFGFileExtension);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(locateFiles.GetSourceFilePath));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(locateFiles.GetTargetFilePath));

            configuratorHandler.Handle(sourceData, targetData);
        }
        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }

        public static bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile, string extension, string path)
        {
            if (sourceFile.FileName.CheckFileExtention(extension) &&
                targetFile.FileName.CheckFileExtention(extension))
            {
                ConfigurationWriter.Write(sourceFile, path);
                ConfigurationWriter.Write(targetFile, path);

                return true;
            }

            return false;
        }

        public ComparatorResponseDTO GetResponse(IFormFile sourceFile, IFormFile targetFile, string path)
        {
            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(sourceFile.FileName.GetCurrentPath(path)));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(targetFile.FileName.GetCurrentPath(path)));

            configuratorHandler.Handle(sourceData, targetData);

            return new ComparatorResponseDTO { 
                 SourceFileName = sourceFile.FileName,
                 TargetFileName = targetFile.FileName,
                 ComparatorParameters = configuratorHandler.GetComparatorData()
            };
        }

        public ComparatorResponseDTO GetFilteredBy(FilterByIdDTO filterById, string path)
        {
            var sourceData = ConfiguratorReader.Read(filterById.SourceFileName.GetCurrentPath(path));
            var targetData = ConfiguratorReader.Read(filterById.TargetFileName.GetCurrentPath(path));

            configuratorHandler.Handle(sourceData, targetData);

            var data = configuratorHandler.GetComparatorData().FilterById(filterById.Id);

            return new ComparatorResponseDTO
            {
                SourceFileName = filterById.SourceFileName,
                TargetFileName = filterById.TargetFileName,
                ComparatorParameters = data,
            };
        }

        public bool FilesArePresent(string source, string target, string extension, string path)
        {
            return extension.CheckFile(path, source) && extension.CheckFile(path, target);
        }
    }
}
