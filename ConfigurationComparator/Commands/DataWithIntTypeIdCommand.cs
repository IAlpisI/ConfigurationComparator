using ConfigurationComparator.ConfigurationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationComparator.Commands
{
    public class DataWithIntTypeIdCommand : ICommand
    {
        private readonly IConsole _console;
        public DataWithIntTypeIdCommand(IConsole console)
        {
            _console = console;
        }
        public void Execute(IEnumerable<ComparatorParameters> cp)
        {
            var data = cp.Where(x => x.IsStatusAvailable());

            _console.PrintListOfData(data);
        }
    }
}
