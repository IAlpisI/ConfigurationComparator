using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Commands
{
    public class DataWithIntTypeIdCommand : Command
    {
        public DataWithIntTypeIdCommand(IMessageWriter messageWriter):base(messageWriter)
        {
        }

        /// <summary>
        /// Filter data with only string type ids
        /// </summary>
        /// <param name="comp">Comparator parameters</param>
        public override void Execute(IEnumerable<ComparatorParameters> comp)
        {
            var data = comp.Where(x => x.IsStatusAvailable());

            _messageWriter.WriteData(data);
        }
    }
}
