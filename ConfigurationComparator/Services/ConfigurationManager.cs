using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;
using ConfigurationComparator.Cache.ConfigurationFile;

namespace ConfigurationComparator.ConfigurataionService
{
    public class ConfigurationManager
    {
        private readonly CommandHandler commandHandler;
        private readonly LocateFiles locateFiles;
        private readonly ConfiguratorHandler configuratorHandler;
        private readonly IConfFileCache _confFileCache;
        public ConfigurationManager(IWriter messageWriter, IReader messageReader, IConfFileCache confFileCache)
        {
            commandHandler = new CommandHandler(messageWriter, messageReader);
            locateFiles = new LocateFiles(messageWriter, messageReader);
            configuratorHandler = new ConfiguratorHandler();
            _confFileCache = confFileCache;
        }

        public void InitializeData(string path)
        {
            var sourceFileName = locateFiles.LookForFile(path, FileType.Source);
            var targetFileName = locateFiles.LookForFile(path, FileType.Target);

            if (!_confFileCache.TryGetConfigurationValue(sourceFileName, out var sourceData))
            {
                sourceData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(sourceFileName, path));
                _confFileCache.AddValue(sourceFileName, sourceData);
            }

            if(!_confFileCache.TryGetConfigurationValue(targetFileName, out var targetData))
            {
                targetData = ConfiguratorReader.Read(ConfiguratorReader.Decompose(targetFileName, path));
                _confFileCache.AddValue(targetFileName, targetData);
            }

            configuratorHandler.Handle(sourceData, targetData);
        }

        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }
    }
}
