using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public interface IVisitor
    {
        public void Visit(ConfigurationParameters param, List<ConfigurationParameters> type, ref List<ComparatorParameters> data);
    }
}
