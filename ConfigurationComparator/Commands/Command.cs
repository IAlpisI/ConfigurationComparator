using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public abstract class Command
    {
        protected IDataProcess _dataProcess;
        public Command(IDataProcess dataProcess)
        {
            _dataProcess = dataProcess;
        }
        public abstract void Execute(IEnumerable<ComparatorParameters> cp);
    }
}
