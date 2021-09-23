using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class CommandHandler
    {
        private readonly Dictionary<int, Command> Commands;
        private readonly IDataProcess _console;

        public CommandHandler(IDataProcess console)
        {
            _console = console;

            Commands = new Dictionary<int, Command>
            {
                { 1, new FilterCommand(console) },
                { 2, new ViewReportCommand(console) },
                { 3, new DataWithStringTypeIdCommand(console) },
                { 4, new DataWithIntTypeIdCommand(console) },
            };
        }

        public void Handle(int command, IEnumerable<ComparatorParameters> cp)
        {
            if(Commands.TryGetValue(command, out _))
            {
                Commands[command].Execute(cp);
            }
        }

        public void StartCommands(List<ComparatorParameters> param)
        {
            while (true)
            {
                _console.Print("1 to filter " +
                    "\n2 to view report \n3 to view records with string type ids " +
                    "\n4 to view records with int type ids \nQ to finish ");

                var command = _console.ReadInput();
                if(int.TryParse(command, out var nr))
                {
                    Handle(nr, param);
                }

                if(command.Equals('Q'))
                {
                    break;
                }
            }
        }
    }
}
