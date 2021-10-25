using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurataionService
{
    public class ConfigurationManager
    {
        private readonly CommandHandler commandHandler;
        private readonly LocateFiles locateFiles;
        private readonly ConfiguratorHandler configuratorHandler;
        public ConfigurationManager(IWriter messageWriter, IReader messageReader)
        {
            commandHandler = new CommandHandler(messageWriter, messageReader);
            locateFiles = new LocateFiles(messageWriter, messageReader);
            configuratorHandler = new ConfiguratorHandler();
        }

        public void InitializeData(string path)
        {
            var sourceFileName = locateFiles.LookForFile(path, FileType.Source);
            var targetFileName = locateFiles.LookForFile(path, FileType.Target);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(sourceFileName, path));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(targetFileName, path));

            SetConfigurationHandler(sourceData, targetData);
        }

        public void SetConfigurationHandler(IEnumerable<ConfigurationParameters> source, IEnumerable<ConfigurationParameters> target)
        {
            configuratorHandler.Handle(source, target);
        }

        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }
    }
}
