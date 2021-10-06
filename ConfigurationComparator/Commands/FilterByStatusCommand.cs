using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Logging;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class FilterByStatusCommand : Command
    {
        private readonly IMessageReader _messageReader;
        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };
        public FilterByStatusCommand(IMessageReader messageReader, IMessageWriter messageWriter): base(messageWriter)
        {
            _messageReader = messageReader;
        }
        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            List<Status> filter = new();
            int statusNumber = 4;

            _messageWriter.Write("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var statutes = _messageReader.Read();

            for (int x = 0; x < statusNumber; x++)
            {
                if (statutes.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            _messageWriter.WriteData(cp.FilterByStatus(filter));
        }
    }
}
