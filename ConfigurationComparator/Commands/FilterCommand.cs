using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class FilterCommand : Command
    {
        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
        public FilterCommand(IDataProcess dataProcess):base(dataProcess)
        {
        }

        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            List<Status> filter = new();
            int filterNumber = 4;

            _dataProcess.Print("Write id");
            var id = _dataProcess.ReadInput();
            _dataProcess.Print("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var filters = _dataProcess.ReadInput();

            for (int x = 0; x < filterNumber; x++)
            {
                if (filters.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            _dataProcess.PrintListOfData(cp.Filter(filter, id));
        }
    }
}
