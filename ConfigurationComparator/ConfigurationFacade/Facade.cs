using ConfigurationComparator.Commands;
using ConfigurationComparator.ConfigurationVisitor;
using ConfigurationComparator.Enums;
using ConfigurationComparator.HandleFiles;

namespace ConfigurationComparator.ConfigurataionFacade
{
    public class Facade
    {
        private readonly IConsole _console;
        private readonly CommandHandler commandHandler;
        private readonly LocateFiles locateFiles;
        private readonly ConfiguratorHandler configuratorHandler;
        public Facade(IConsole console)
        {
            _console = console;
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
        public void RunCommands()
        {
            bool run = true;
            while (run)
            {
                _console.PrintToConsole("1 to filter " +
                    "\n2 to view report \n3 to view records with string type ids " +
                    "\n4 to view records with int type ids \nQ to finish ");

                var command = _console.ReadInput();
                if(int.TryParse(command, out var nr))
                {
                    commandHandler.Handle(nr, configuratorHandler.GetComparatorData());
                }

                if(command.Equals('Q'))
                {
                    break;
                }
            }
        }
    }
}
