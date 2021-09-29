using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class CommandHandler
    {
        private readonly Dictionary<int, Command> Commands;
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;

        public CommandHandler(IMessageWriter messageWriter, IMessageReader messageReader)
        {
            _messageWriter = messageWriter;
            _messageReader = messageReader;

            Commands = new Dictionary<int, Command>
            {
                { 1, new FilterCommand(messageWriter, messageReader) },
                { 2, new ViewReportCommand(messageWriter) },
                { 3, new DataWithStringTypeIdCommand(messageWriter) },
                { 4, new DataWithIntTypeIdCommand(messageWriter) },
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

                var command = _messageReader.Read();
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
                _messageWriter.Write($"Press {c.Key} to activate {commandName}");
            }
            _messageWriter.Write("Press Q to finish");
        }
    }
}
