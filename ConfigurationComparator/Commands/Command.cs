using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public abstract class Command
    {
        protected IMessageWriter _messageWriter;
        public Command(IMessageWriter messageWriter)
        {
            _messageWriter = messageWriter;
        }
        public abstract void Execute(IEnumerable<ComparatorParameters> cp);
    }
}
