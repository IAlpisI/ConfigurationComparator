using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using ConfigurationComparator.Logging;
using System.Collections.Generic;

namespace ConfigurationComparator.Commands
{
    public class FilterByIdCommand : Command
    {
        private readonly IMessageReader _messageReader;
        public FilterByIdCommand(IMessageWriter messageWriter, IMessageReader messageReader) : base(messageWriter)
        {
            _messageReader = messageReader;
        }
        public override void Execute(IEnumerable<ComparatorParameters> cp)
        {
            _messageWriter.Write("Write id");
            var id = _messageReader.Read();

            _messageWriter.WriteData(cp.FilterById(id));
        }
    }
}
