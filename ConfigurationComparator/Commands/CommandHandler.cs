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
        private readonly IConsole console;

        public CommandHandler(IConsole console)
        {
            Commands = new Dictionary<int, ICommand>
            {
                { 1, new FilterCommand(console) },
                //{ 2, new ViewFilesCommand(sourceFile, targetFile, console) },
                { 2, new ViewReportCommand(console) },
                { 3, new FilterCommand(console) },
                { 4, new FilterCommand(console) },
            };
        }

        public void Handle(int command, IEnumerable<ComparatorParameters> cp)
        {
            if(Commands.TryGetValue(command, out _))
            {
                Commands[command].Execute(cp);
            }
        }
    }
}
