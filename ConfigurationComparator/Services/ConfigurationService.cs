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
using System.IO;

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

        public static bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile, string extension)
        {
            var sourceFileName = sourceFile.FileName;
            var targetFileName = targetFile.FileName;
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"Upload");

            if (sourceFileName.CheckFileExtention(extension) 
                && targetFileName.CheckFileExtention(extension))
            {
                ConfigurationWriter.Write(sourceFile, directoryPath);
                ConfigurationWriter.Write(targetFile, directoryPath);

                return true;
            }

            return false;
        }

        public ComparatorResponseDTO GetResponse(IFormFile sourceFile, IFormFile targetFile)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"Upload");
            var sourceFilePath = Path.Combine(directoryPath, sourceFile.FileName);
            var targetFilePath = Path.Combine(directoryPath, targetFile.FileName);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(sourceFilePath));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(targetFilePath));

            configuratorHandler.Handle(sourceData, targetData);

            return new ComparatorResponseDTO { 
                 SourceFileName = sourceFile.FileName,
                 TargetFileName = targetFile.FileName,
                 ComparatorParameters = configuratorHandler.GetComparatorData()
            };
        }

        public bool FilesArePresent(string source, string target, string extension, string path)
        {
            return extension.CheckFile(path, source) && extension.CheckFile(path, target);
        }
    }
}
