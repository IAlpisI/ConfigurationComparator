using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;

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
    }
}
