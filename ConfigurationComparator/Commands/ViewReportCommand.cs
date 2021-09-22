using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class ViewReportCommand : ICommand
    {
        private readonly IConsole _console;
        public ViewReportCommand(IConsole console)
        {
            _console = console;
        }

        public void Execute(IEnumerable<ComparatorParameters> cp)
        {
            _console.PrintListOfData(cp.GetReport());
        }
    }
}
