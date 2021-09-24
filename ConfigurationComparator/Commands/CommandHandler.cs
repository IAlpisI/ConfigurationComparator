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

        private void Handle(int command, IEnumerable<ComparatorParameters> cp)
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
                DisplayCommands();

                var command = _console.ReadInput();
                if(int.TryParse(command, out var nr))
                {
                    Handle(nr, param);
                }

                if(command.Equals("Q"))
                {
                    break;
                }
            }
        }

        private void DisplayCommands()
        {
            foreach (var c in Commands)
            {
                var commandName = c.Value.ToString().Split('.')[^1];
                _console.Print($"Press {c.Key} to activate {commandName}");
            }
            _console.Print("Press Q to finish");
        }
    }
}
