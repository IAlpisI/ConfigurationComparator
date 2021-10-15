using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;

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
            var sourcePath = locateFiles.LookForFile(path, FileType.Source);
            var targetPath = locateFiles.LookForFile(path, FileType.Target);

            var sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(sourcePath));
            var targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(targetPath));

            configuratorHandler.Handle(sourceData, targetData);
        }

        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }
    }
}
