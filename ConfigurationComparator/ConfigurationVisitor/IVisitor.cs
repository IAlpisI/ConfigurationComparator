using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public interface IVisitor
    {
        public void Visit(ConfigurationParameters param, IEnumerable<ConfigurationParameters> type, ref List<ComparatorParameters> data);
    }
}
