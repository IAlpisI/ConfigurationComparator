using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public abstract class Command
    {
        protected IWriter _messageWriter;
        public Command(IWriter messageWriter)
        {
            _messageWriter = messageWriter;
        }
        public abstract void Execute(IEnumerable<ComparatorParameters> comp);
    }
}
