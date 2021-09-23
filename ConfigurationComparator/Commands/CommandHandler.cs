using ConfigurationComparator.ConfigurationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationComparator.Commands
{
    public class CommandHandler
    {
        private readonly Dictionary<int, ICommand> Commands;
        private readonly IConsole _console;

        public CommandHandler(IConsole console)
        {
            _console = console;

            Commands = new Dictionary<int, ICommand>
            {
                { 1, new FilterCommand(console) },
                { 2, new ViewReportCommand(console) },
                { 3, new DataWithStringTypeIdCommand(console) },
                //{ 4, new DataWithIntTypeIdCommand(console) },
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
                _console.PrintToConsole("1 to filter " +
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
