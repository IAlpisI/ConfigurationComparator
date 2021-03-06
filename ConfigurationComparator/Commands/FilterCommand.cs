using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class FilterCommand : Command
    {
        private readonly IReader _messageReader;
        private readonly List<Status> Statuses = new() { Status.Added, Status.Modified, Status.Removed, Status.Unchanged };

        public FilterCommand(IWriter messageWriter, IReader messageReader) : base(messageWriter)
        {
            _messageReader = messageReader;
        }

        /// <summary>
        /// User types id and selects filters that will be used to filter the collection.
        /// </summary>
        /// <param name="comp">Comparator parameters</param>
        public override void Execute(IEnumerable<ComparatorParameters> comp)
        {
            List<Status> filter = new();
            int filterNumber = 4;

            _messageWriter.Write("Write id");
            var id = _messageReader.Read();
            _messageWriter.Write("Select filters \n0 - Added \n1 - Modified \n2 - Removed \n3 - Unchanged ");
            var filters = _messageReader.Read();

            for (int x = 0; x < filterNumber; x++)
            {
                if (filters.Contains(x.ToString()))
                {
                    filter.Add(Statuses[x]);
                }
            }

            _messageWriter.WriteData(comp.Filter(filter, id));
        }
    }
}
