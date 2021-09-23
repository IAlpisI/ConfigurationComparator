using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Extensions;
using System;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class ConfigurationVisitor : IVisitor
    {
        public void Visit(ConfigurationParameters param, List<ConfigurationParameters> source, ref List<ComparatorParameters> data)
        {
            if (source.TryToFindById(param.Id, out var val))
            {
                data.Add(new ComparatorParameters(val, param));
                source.Remove(val);
            } else
            {
                data.Add(new ComparatorParameters(new ConfigurationParameters(), param));
            }
        }
    }
}
