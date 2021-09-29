using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Commands
{
    public class DataWithStringTypeIdCommand : Command
    {
        public DataWithStringTypeIdCommand(IMessageWriter messageWriter) :base(messageWriter)
        {
        }
        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            var data = cp.Where(x => !x.IsStatusAvailable());

            _messageWriter.WriteData(data);
        }
    }
}
