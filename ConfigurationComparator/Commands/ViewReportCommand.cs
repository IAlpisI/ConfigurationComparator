using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class ViewReportCommand : Command
    {
        public ViewReportCommand(IDataProcess dataProcess):base(dataProcess)
        {
        }

        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            _dataProcess.PrintListOfData(cp.GetReport());
        }
    }
}
