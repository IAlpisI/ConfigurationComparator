using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;

namespace ConfigurationComparator.ConfigurataionFacade
{
    public class Facade
    {
        private readonly CommandHandler commandHandler;
        private readonly LocateFiles locateFiles;
        private readonly ConfiguratorHandler configuratorHandler;
        public Facade(IConsole console)
        {
            commandHandler = new CommandHandler(console);
            locateFiles = new LocateFiles(console);
            configuratorHandler = new ConfiguratorHandler();
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
    }
}
