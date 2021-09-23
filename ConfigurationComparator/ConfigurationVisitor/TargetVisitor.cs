using ConfigurationComparator.ConfigurationHandler;
using ConfigurationComparator.Enums;
using ConfigurationComparator.Extensions;
using System.Collections.Generic;

namespace ConfigurationComparator.ConfigurationVisitor
{
    public class TargetVisitor
    {
        public void Visit(ConfigurationParameters param, IEnumerable<ConfigurationParameters> source, ref List<ComparatorParameters> data)
        {
            if (!source.TryToFindById(param.Id, out _))
            {
                var comp = new ComparatorParameters(param);

                comp.SetStatus(Status.Added);
                data.Add(comp);
            }
        }
    }
}
