using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;
using ConfigurationComparator.Logging;
using System.Collections.Generic;
using ConfigurationComparator.Cache;

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

            var sourceData = GetFileData(CacheKeys.Source, sourceFileName, path);
            var targetData = GetFileData(CacheKeys.Target, targetFileName, path);

            configuratorHandler.Handle(sourceData, targetData);
        }

        public void InitializeCommands()
        {
            commandHandler.StartCommands(configuratorHandler.GetComparatorData());
        }

        private IEnumerable<ConfigurationParameters> GetFileData(string key, string fileName, string path)
        {
            if (!_confFileCache.TryGetConfigurationValues(key, out var data))
            {
                data = ConfiguratorReader.Read(ConfiguratorReader.Decompose(fileName, path));
                _confFileCache.AddConfigurationValues(key, data);
            }

            return data;
        }
    }
}
