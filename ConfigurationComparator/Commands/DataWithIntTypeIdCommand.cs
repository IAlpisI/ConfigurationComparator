using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Commands
{
    public class DataWithIntTypeIdCommand : Command
    {
        public DataWithIntTypeIdCommand(IDataProcess dataProcess):base(dataProcess)
        {
        }
        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            var data = cp.Where(x => x.IsStatusAvailable());

            _dataProcess.PrintListOfData(data);
        }
    }
}
