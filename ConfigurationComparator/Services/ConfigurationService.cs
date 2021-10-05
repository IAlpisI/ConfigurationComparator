using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
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
        }

        public void InitializeData()
        {
            locateFiles.LookForFile(FileType.Target, Constants.CFGFileExtension);
            locateFiles.LookForFile(FileType.Source, Constants.CFGFileExtension);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(locateFiles.GetSourceFile));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(locateFiles.GetTargetFile));

            configuratorHandler.Handle(sourceData, targetData);
        }
        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }

        public bool TryUploadFiles(IFormFile sourceFile, IFormFile targetFile, string extension)
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
            var response = new ComparatorResponseDTO();


            return response;
        }

        public bool FilesArePresent(IFormFile file, string extension)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"Upload");

            return locateFiles.CheckFile(extension, directoryPath, file.FileName);
        }
    }
}
