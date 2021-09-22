using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class FilterCommand : ICommand
    {
        private readonly IConsole _console;
        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
        public FilterCommand(IConsole console)
        {
            _console = console;
        }

        public void Execute(IEnumerable<ComparatorParameters> cp)
        {
            List<Status> filter = new();
            int filterNumber = 4;

            _console.PrintToConsole("Write id");
            var id = _console.ReadInput();
            _console.PrintToConsole("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var filters = _console.ReadInput();

            for (int x = 0; x < filterNumber; x++)
            {
                if (filters.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            _console.PrintListOfData(cp.Filter(filter, id));
        }
    }
}
