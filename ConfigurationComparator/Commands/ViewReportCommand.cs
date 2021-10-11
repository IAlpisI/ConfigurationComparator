using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class ViewReportCommand : Command
    {
        public ViewReportCommand(IMessageWriter messageWriter):base(messageWriter)
        {
        }

        /// <summary>
        /// Get report based on collection of <see cref="ComparatorParameters"/>
        /// </summary>
        /// <param name="comp">Comparator parameters</param>
        public override void Execute(IEnumerable<ComparatorParameters> comp)
        {
            _messageWriter.WriteData(comp.GetReport());
        }
    }
}
