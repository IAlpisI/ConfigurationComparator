using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class ConfiguratorHandler
    {
        private List<ComparatorParameters> comparatorParameters;
        public List<ComparatorParameters> GetComparatorData() => comparatorParameters;

        public ConfiguratorHandler()
        {
            comparatorParameters = new List<ComparatorParameters>();
        }
        public void Handle(IEnumerable<ConfigurationParameters> source, IEnumerable<ConfigurationParameters> target)
        {
            var fileVisitor = new ConfigurationVisitor();
            var sourceCopy = new List<ConfigurationParameters>(source);

            foreach(var t in target)
            {
                fileVisitor.Visit(t, sourceCopy, ref comparatorParameters);
            }

            foreach(var sc in sourceCopy)
            {
                comparatorParameters.Add(new ComparatorParameters(sc));
            }
        }
    }
}
