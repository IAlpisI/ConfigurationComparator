using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class ConfiguratorHandler
    {
        private List<ComparatorParameters> dataWithIntTypeIds;
        private readonly List<ConfigurationParameters> dataWithStringTypeIds;

        public List<ComparatorParameters> GetIntTypeData() => dataWithIntTypeIds;
        public List<ConfigurationParameters> GetStringTypeData() => dataWithStringTypeIds;

        public ConfiguratorHandler()
        {
            dataWithIntTypeIds = new List<ComparatorParameters>();
            dataWithStringTypeIds = new List<ConfigurationParameters>();
        }
        public void Handle(IEnumerable<ConfigurationParameters> source, IEnumerable<ConfigurationParameters> target)
        {
            var targetVisitor = new TargetVisitor();
            var sourceVisitor = new SourceVisitor();

            Compare(source, sourceVisitor, target);
            Compare(target, targetVisitor, source);
        }

        private void Compare(IEnumerable<ConfigurationParameters> initData, IVisitor visitor, IEnumerable<ConfigurationParameters> compareData)
        {
            foreach (var d in initData)
            {
                if (!int.TryParse(d.Id, out _))
                {
                    dataWithStringTypeIds.Add(new ConfigurationParameters(d.Id, d.Value));
                    continue;
                }

                visitor.Visit(d, compareData, ref dataWithIntTypeIds);
            }
        }
    }
}
