using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class CommandHandler
    {
        private readonly Dictionary<int, Command> Commands;
        private readonly IWriter _messageWriter;
        private readonly IReader _messageReader;

        public CommandHandler(IWriter messageWriter, IReader messageReader)
        {
            _messageWriter = messageWriter;
            _messageReader = messageReader;

            Commands = new Dictionary<int, Command>
            {
                { 0, new FilterCommand(messageWriter, messageReader) },
                { 1, new ViewReportCommand(messageWriter) },
                { 2, new DataWithStringTypeIdCommand(messageWriter) },
                { 3, new DataWithIntTypeIdCommand(messageWriter) },
            };
        }

        /// <summary>
        /// Look inside the <see cref="Dictionary{int, Command}"/> for a command and execute it
        /// </summary>
        /// <param name="command">Index of command</param>
        /// <param name="comp">Comparator parameters</param>
        private void Handle(int command, IEnumerable<ComparatorParameters> comp)
        {
            if (Commands.TryGetValue(command, out _))
            {
                Commands[command].Execute(comp);
            }
        }

        /// <summary>
        /// Read user's input and set it as a command
        /// </summary>
        /// <param name="comp">Comparator parameters</param>
        public void StartCommands(IEnumerable<ComparatorParameters> comp)
        {
            DisplayCommands();

            var command = _messageReader.Read();
            if (int.TryParse(command, out var nr))
            {
                Handle(nr, comp);
            }
        }

        /// <summary>
        /// Show names of the commands
        /// </summary>
        private void DisplayCommands()
        {
            foreach (var c in Commands)
            {
                var commandName = c.Value.ToString().Split('.')[^1];
                _messageWriter.Write($"Press {c.Key} to activate {commandName}");
            }
        }
    }
}
