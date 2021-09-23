using ConfigurationComparator.ConfigurationHandler;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class ConfiguratorHandler
    {
        private List<ComparatorParameters> comparatorParameters;
        private readonly List<ConfigurationParameters> dataWithStringTypeIds;

        public List<ComparatorParameters> GetComparatorData() => comparatorParameters;
        public List<ComparatorParameters> GetIntTypeData() => comparatorParameters;
        public List<ConfigurationParameters> GetStringTypeData() => dataWithStringTypeIds;

        public ConfiguratorHandler()
        {
            comparatorParameters = new List<ComparatorParameters>();
            dataWithStringTypeIds = new List<ConfigurationParameters>();
        }
        public void Handle(IEnumerable<ConfigurationParameters> source, IEnumerable<ConfigurationParameters> target)
        {
            var fileVisitor = new ConfigurationVisitor();

            //var targetVisitor = new TargetVisitor();
            //var sourceVisitor = new SourceVisitor();

            //Compare(source, sourceVisitor, target);
            //Compare(target, targetVisitor, source);

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

        //private void Compare(IEnumerable<ConfigurationParameters> initData, IVisitor visitor, IEnumerable<ConfigurationParameters> compareData)
        //{
        //    foreach (var d in initData)
        //    {
        //        if (!int.TryParse(d.Id, out _))
        //        {
        //            dataWithStringTypeIds.Add(new ConfigurationParameters(d.Id, d.Value));
        //            continue;
        //        }
        //        visitor.Visit(d, compareData, ref dataWithIntTypeIds);
        //    }
        //}
    }
}
