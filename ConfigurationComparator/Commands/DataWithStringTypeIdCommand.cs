using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.Commands
{
    public class DataWithStringTypeIdCommand : Command
    {
        public DataWithStringTypeIdCommand(IDataProcess dataProcess):base(dataProcess)
        {
        }
        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            var data = cp.Where(x => !x.IsStatusAvailable());

            _dataProcess.PrintListOfData(data);
        }
    }
}
