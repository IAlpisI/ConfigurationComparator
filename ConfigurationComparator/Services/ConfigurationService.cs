using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;
using ConfigurationComparatorAPI.Dtos;
//using ConfigurationComparator.Dto
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
            locateFiles.LookForFile(FileType.Target);
            locateFiles.LookForFile(FileType.Source);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(locateFiles.GetSourceFile));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(locateFiles.GetTargetFile));

            configuratorHandler.Handle(sourceData, targetData);
        }
        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }

        public bool TryUploadFiles(string sourceFileName, string targetFileName, string extension)
        {
            if (sourceFileName.CheckFileExtention(extension) 
                && targetFileName.CheckFileExtention(extension))
            {



                return true;
            }

            return false;
            //return Path.Combine(Directory.GetCurrentDirectory(), @"Upload/files");
        }
    }
}
