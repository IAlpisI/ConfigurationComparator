using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class ConfigurationVisitor : IVisitor
    {
        /// <summary>
        /// If the target parameter exists in source collection they are both added to the compared collection; otherwise, only the target parameter is added.
        /// </summary>
        /// <param name="conf">Target parameter</param>
        /// <param name="source">Source</param>
        /// <param name="data">Compared</param>
        public void Visit(ConfigurationParameters conf, List<ConfigurationParameters> source, ref List<ComparatorParameters> data)
        {
            if (source.TryToFindById(conf.Id, out var val))
            {
                data.Add(new ComparatorParameters(val, conf));
                source.Remove(val);
            } else
            {
                data.Add(new ComparatorParameters(new ConfigurationParameters(), conf));
            }
        }
    }
}
