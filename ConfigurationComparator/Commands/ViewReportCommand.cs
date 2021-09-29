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

        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            _messageWriter.WriteData(cp.GetReport());
        }
    }
}
